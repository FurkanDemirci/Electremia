using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Electremia.ViewModels;
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
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Not all fields are filled correctly!";
                return View();
            }

            var accountServices = _factory.AccountService();
            var user = accountServices.Login(new User{ Username = model.Username, Password = model.Password});

            if (user != null)
            {
                @ViewData["Worked"] = "Successfully logged in!";
            }

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