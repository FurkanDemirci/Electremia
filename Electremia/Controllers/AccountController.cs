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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Electremia.Controllers
{
    public class AccountController : Controller
    {
        // The factory is created to gain access to the logic.
        private readonly Factory _factory;

        public AccountController(IConfiguration config)
        {
            _factory = new Factory(config);
        }

        //TODO Dit is een test voor authenticatie.
        [Authorize(Roles = "Admin")]
        public IActionResult Index()

        {
            /* Getting values back from claims(Cookie).
             * Identity or claims enumerable.
             * Used for test purpose.
             */

            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return View();
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
            var user = accountServices.Login(new User { Username = model.Username, Password = model.Password });

            // Creating claims for user authentication.
            if (user == null) return View();
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

        public IActionResult Unauthorized()
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
                ViewData["Error"] = "Not all fields are filled correctly!";
                return View();
            }

            var accountServices = _factory.AccountService();

            var user = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Username = model.Username,
                Password = model.Password,
                Certificate = model.Certificate
            };
            var registered = accountServices.Register(user);

            if (!registered)
            {
                ViewData["Error"] = "Username already exists.";
                return View();
            }
            ViewData["Worked"] = "Account successfully made!";
            return View();
        }

        public IActionResult Edit(int id)
        {
            var accountServices = _factory.AccountService();
            var fullUser = accountServices.GetFullUser(id);

            if (fullUser == null) return NotFound(id);
            var model = new EditAccountViewModel(fullUser);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditAccountViewModel model)
        {
            //TODO Controleer voor leeg gelaten velden.
            var accountService = _factory.AccountService();
            var jobService = _factory.JobService();
            var schoolService = _factory.SchoolService();

            accountService.Edit(model.User);

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
    }
}