using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Electremia.Logic;
using Electremia.Model.Models;
using Electremia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Electremia.Controllers
{
    [Authorize]
    public class RelationshipController : Controller
    {
        private readonly Factory _factory;

        public RelationshipController(IConfiguration config)
        {
            _factory = new Factory(config);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddFriend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFriend(string username, int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims.ToList();
            var friendServices = _factory.FriendService();

            bool added;
            try
            {
                added = friendServices.AddFriend(Convert.ToInt32(claims[1].Value), id);
            }
            catch (ExceptionHandler e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }

            if (added)
                ViewData["Message"] = "Succesfully send request";
            else
                ViewData["Message"] = "Couldn't send request";

            return View();
        }

        public IActionResult Requests()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims.ToList();
            var friendServices = _factory.FriendService();

            var relationships = new List<RelationshipViewModel>();
            try
            {
                var results = friendServices.GetPending(Convert.ToInt32(claims[1].Value));
                foreach (var relationship in results)
                {
                    var relationshipViewModel = new RelationshipViewModel
                    {
                        Relationship = relationship.Value,
                        Username = relationship.Key
                    };
                    relationships.Add(relationshipViewModel);
                }
            }
            catch (ExceptionHandler e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }

            return View(relationships);
        }
    }
}