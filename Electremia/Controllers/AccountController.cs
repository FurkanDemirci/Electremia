using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electremia.Logic.Services;
using Electremia.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Electremia.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountServices _accountServices;

        public AccountController()
        {
            _accountServices = new AccountServices();
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
            if ((model.Username == null) || (model.Password == null))
            {
                @ViewData["Error"] = "Don't leave empty!";
            }

            var user = _accountServices.Login(model);

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
            if ((model.Username == null) || (model.Password == null) || (model.Firstname == null) || (model.Lastname == null))
            {
                ViewData["Error"] = "Don't leave empty!";
                return View();
            }

            var registered = _accountServices.Register(model);
            if (!registered)
            {
                ViewData["Error"] = "Something went wrong!";
                return View();
            }

            ViewData["Worked"] = "Account successfully made!";
            return View();
        }
    }
}