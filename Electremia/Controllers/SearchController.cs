﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Electremia.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            if (search == null)
            {
                search = "";
            }
            var lowerSearch = search.ToLower();
            switch (lowerSearch)
            {
                case "login":
                    return RedirectToAction("Login", "Account");
                case "register":
                    return RedirectToAction("Register", "Account");
                case "home":
                    return RedirectToAction("Index", "Home");
                default:
                    return RedirectToAction("Profile", "Account", new {usr = search});
            }
        }
    }
}