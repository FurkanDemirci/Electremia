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
            var accountServices = _factory.AccountService();

            if ((model.Username == null) || (model.Password == null))
            {
                @ViewData["Error"] = "Don't leave empty!";
            }

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
            var accountServices = _factory.AccountService();

            if ((model.Username == null) || (model.Password == null) || (model.Firstname == null) || (model.Lastname == null))
            {
                ViewData["Error"] = "Don't leave empty!";
                return View();
            }

            var registered = accountServices.Register(new User{ Firstname = model.Firstname, Lastname = model.Lastname, Username = model.Username, Password = model.Password});
            if (!registered)
            {
                ViewData["Error"] = "Something went wrong!";
                return View();
            }

            ViewData["Worked"] = "Account successfully made!";
            return View();
        }

        public IActionResult Edit(int id)
        {
            var accountServices = _factory.AccountService();
            var jobServices = _factory.JobService();
            var schoolServices= _factory.SchoolService();

            var user = accountServices.GetAccount(id);
            if (user == null)
            {
                return NotFound(id);
            }
            
            var jobs = jobServices.GetAll(id);
            var schools = schoolServices.GetAll(id);
            var model = new EditAccountViewModel(user, (List<Job>)jobs, (List<School>)schools);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditAccountViewModel model)
        {
            var accountServices = _factory.AccountService();

            var accountUpdated = accountServices.Edit(model.User);
            //var jobUpdated = _jobServices.Add(model.User.Jobs);

            var jobUpdated = true;
            if ((!accountUpdated) || (!jobUpdated))
            {
                ViewData["Error"] = "Update failed";
                return View(model);
            }

            if (model.User.Jobs == null)
            {
                model.User.Jobs = new List<Job>();
            }

            if (model.User.Schools == null)
            {
                model.User.Schools = new List<School>();
            }

            ViewData["Worked"] = "Account successfully updated!";
            return View(model);
        }
    }
}