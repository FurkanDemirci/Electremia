using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electremia.Controllers
{
    public class TimelineController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            //TODO Krijg alle content van je zelf en je vrienden te zien in Index.
            return View();
        }

        [Authorize]
        public IActionResult CreateContent()
        {
            //TODO Creëer alle soorten content (Post en Product) en stuur het op.
            return View();
        }
    }
}