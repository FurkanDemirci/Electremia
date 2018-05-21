using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Electremia.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Electremia.Controllers
{
    public class AccountController : Controller
    {
        // The services that's going to be needed.
        private readonly AccountServices _accountServices;
        private readonly JobServices _jobServices;
        private readonly SchoolServices _schoolServices;
        private readonly FriendServices _friendServices;

        // Getting the HostingEnviroment for media purposes.
        private readonly IHostingEnvironment _environment;

        public AccountController(IConfiguration config, IHostingEnvironment environment)
        {
            _environment = environment;

            // Services using for AccountController:
            _accountServices = new Factory(config).AccountService();
            _jobServices = new Factory(config).JobService();
            _schoolServices = new Factory(config).SchoolService();
            _friendServices = new Factory(config).FriendService();
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Profile", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Not all fields are filled correctly!";
                return View();
            }

            User user;
            try { user = _accountServices.Login(model.Username, model.Password); }
            catch (ExceptionHandler e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }

            var cookies = user.Admin ? new Cookies(user.Username, user.UserId.ToString(), "Admin") : new Cookies(user.Username, user.UserId.ToString());
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                cookies.ClaimsPrincipal(),
                cookies.AuthProperties());

            return RedirectToAction("Index", "Timeline");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "Succesfully logged out";
            return RedirectToAction("Index", "Home");
        }

        public new IActionResult Unauthorized()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Not all fields are filled correctly!";
                return View();
            }

            try { _accountServices.Register(model.Firstname, model.Lastname, model.Username, model.Password, model.Certificate); }
            catch (ExceptionHandler e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }

            ViewData["Message"] = "Account successfully made!";
            return View();
        }

        [Authorize]
        public IActionResult Profile(string usr)
        {
            if (usr == null)
                usr = User.Identity.Name;

            var userId = 0;
            User fullUser;
            var isFriendsWith = true;

            try
            {
                var user = _accountServices.GetUser(usr);
                if (user != null)
                    userId = user.UserId;
                else
                {
                    TempData["Message"] = "No user found by the name: " + usr;
                    return RedirectToAction("Index", "Search");
                }
            }
            catch (ExceptionHandler e) { return BadRequest(e.Message); }
            try { fullUser = _accountServices.GetFullUser(userId); }
            catch (ExceptionHandler e) { return BadRequest(e.Message); }

            if (usr != User.Identity.Name)
            {
                try { isFriendsWith = _friendServices.CheckRelationship(Cookies.GetId(User), fullUser.UserId); }
                catch (ExceptionHandler e) { return BadRequest(e.Message); }
            }

            var profile = new ProfileViewModel
            {
                UserId = fullUser.UserId,
                Username = fullUser.Username,
                Firstname = fullUser.Firstname,
                Lastname = fullUser.Lastname,
                ProfilePicture = fullUser.ProfilePicture,
                CoverPicture = fullUser.CoverPicture,
                Certificate = fullUser.Certificate,
                Admin = fullUser.Admin,
                Jobs = fullUser.Jobs,
                Schools = fullUser.Schools,
                IsFriendsWith = isFriendsWith
            };

            return View(profile);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                if (Cookies.GetRole(User) != "Admin")
                    return RedirectToAction("Unauthorized", "Account");
            }
            else
                id = Cookies.GetId(User);

            User fullUser;
            try { fullUser = _accountServices.GetFullUser(id); }
            catch (ExceptionHandler e) { return BadRequest(e.Message); }

            if (fullUser == null) return NotFound(id);
            var model = new EditAccountViewModel(fullUser);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditAccountViewModel model)
        {
            // TODO Foto's worden nu geupload naar wwwroot maar dit moet worden geuploaden naar cloud.
            // Profile picture upload.
            if (model.ProfileFormFile != null)
                model.User.ProfilePicture = FileUpload(model.ProfileFormFile);
            // Cover picture upload.
            if (model.CoverFormFile != null)
                model.User.CoverPicture = FileUpload(model.CoverFormFile);

            try { _accountServices.Edit(model.User); }
            catch (ExceptionHandler e) { return BadRequest(e.Message); }
            
            // Check if jobs and schools aren't empty.
            if (model.User.Jobs.Count != 0)
                _jobServices.Edit(model.User.Jobs);
            if (model.User.Schools.Count != 0)
                _schoolServices.Edit(model.User.Schools);

            ViewData["Message"] = "Account successfully updated!";
            return View(model);
        }

        public string FileUpload(IFormFile formFile)
        {
            //TODO Upload naar cloud storage niet naar wwwroot.
            var guidName = Guid.NewGuid() + formFile.FileName;
            var fileName = Path.Combine(_environment.WebRootPath, "images", guidName);
            formFile.CopyTo(new FileStream(fileName, FileMode.Create));
            return Path.GetFileName(guidName);
        }
    }
}