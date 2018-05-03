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
            var requests = new RequestsViewModel();

            try { requests.RelationshipViewModelsPending = RelationshipDicToList(friendServices.GetPending(Convert.ToInt32(claims[1].Value))); }
            catch (ExceptionHandler e) { ViewData["Message1"] = e.Message; }
            try { requests.RelationshipViewModelsSended = RelationshipDicToList(friendServices.GetSended(Convert.ToInt32(claims[1].Value))); }
            catch (ExceptionHandler e) { ViewData["Message2"] = e.Message; }

            return View(requests);
        }

        [HttpPost]
        public IActionResult Requests(int id, int type)
        {
            Status action = (Status) type;
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims.ToList();
            var friendServices = _factory.FriendService();

            friendServices.SetAccept(Convert.ToInt32(claims[1].Value), id, type);

            return RedirectToAction("Requests", "Relationship");
        }

        private enum Status
        {
            NotImplemented = -1,
            Pending,
            Accept,
            Block,
            Delete
        }

        /// <summary>
        /// Converts given relationship dictionary to List of RelationshipViewModel.
        /// </summary>
        /// <param name="resultDictionary">Dictionary string and Relationship</param>
        /// <returns>List of RelationshipViewModel</returns>
        private List<RelationshipViewModel> RelationshipDicToList(Dictionary<string, Relationship> resultDictionary)
        {
            var relationships = new List<RelationshipViewModel>();
            foreach (var relationship in resultDictionary)
            {
                var relationshipViewModel = new RelationshipViewModel
                {
                    Relationship = relationship.Value,
                    Username = relationship.Key
                };
                relationships.Add(relationshipViewModel);
            }
            return relationships;
        }
    }
}