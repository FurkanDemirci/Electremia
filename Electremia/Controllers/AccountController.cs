using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Electremia.Logic;
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
        // The factory is created to gain access to the logic.
        private readonly Factory _factory;
        private readonly IHostingEnvironment _environment;

        public AccountController(IConfiguration config, IHostingEnvironment environment)
        {
            _environment = environment;
            _factory = new Factory(config);    
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

            var accountServices = _factory.AccountService();
            User user;
            try
            {
                user = accountServices.Login(model.Username, model.Password);
            }
            catch (ExceptionHandler e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }

            // Creating claims for user authentication.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Sid, user.UserId.ToString())
            };

            // Adding Admin if true.
            if (user.Admin)
            {
                var claim = new Claim(ClaimTypes.Role, "Admin");
                claims.Add(claim);
            }

            // Setting claims.
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            //TODO Naar feed? page redirecten.
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
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
            var accountServices = _factory.AccountService();
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Not all fields are filled correctly!";
                return View();
            }

            try
            {
                accountServices.Register(model.Firstname, model.Lastname, model.Username, model.Password, model.Certificate);
            }
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

            User fullUser;
            var accountServices = _factory.AccountService();
            try
            {
                var user = accountServices.GetUser(usr);
                fullUser = accountServices.GetFullUser(user.UserId);
            }
            catch (ExceptionHandler e)
            {
                return BadRequest(e.Message);
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
                Schools = fullUser.Schools
            };

            return View(profile);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims.ToList();

            if (id != 0)
            {
                if (claims.Count != 3)
                {
                    return RedirectToAction("Unauthorized", "Account");
                }               
            }
            else
            {
                id = Convert.ToInt32(claims[1].Value);
            }

            var accountServices = _factory.AccountService();

            User fullUser;
            try
            {
                fullUser = accountServices.GetFullUser(id);
            }
            catch (ExceptionHandler e)
            {
                return BadRequest(e.Message);
            }

            if (fullUser == null) return NotFound(id);
            var model = new EditAccountViewModel(fullUser);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditAccountViewModel model)
        {
            //TODO Controleer voor leeg gelaten velden.
            var accountService = _factory.AccountService();
            var jobService = _factory.JobService();
            var schoolService = _factory.SchoolService();

            // Profile picture upload.
            if (model.ProfileFormFile != null)
                model.User.ProfilePicture = FileUpload(model.ProfileFormFile);
            // Cover picture upload.
            if (model.CoverFormFile != null)
                model.User.CoverPicture = FileUpload(model.CoverFormFile);

            try
            {
                accountService.Edit(model.User);
            }
            catch (ExceptionHandler e)
            {
                return BadRequest(e.Message);
            }
            
            if (model.User.Jobs == null)
                model.User.Jobs = new List<Job>();
            else
                jobService.Edit(model.User.Jobs);

            if (model.User.Schools == null)
                model.User.Schools = new List<School>();
            else
                schoolService.Edit(model.User.Schools);

            ViewData["Worked"] = "Account successfully updated!";
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