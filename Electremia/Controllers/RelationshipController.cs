using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Electremia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Electremia.Controllers
{
    [Authorize]
    public class RelationshipController : Controller
    {
        private readonly FriendServices _friendServices;

        public RelationshipController(IConfiguration config)
        {
            _friendServices = new Factory(config).FriendService();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Friends()
        {
            List<RelationshipViewModel> friends;

            try { friends = RelationshipDicToList(_friendServices.GetAllFriends(Cookies.GetId(User))); }
            catch (ExceptionHandler e) { ViewData["Message"] = e.Message; friends = new List<RelationshipViewModel>(); }

            return View(friends);
        }

        [HttpPost]
        public IActionResult Friends(int id1, int id2)
        {
            var userId = Cookies.GetId(User);

            if (id1 != userId)
                id2 = id1;

            TempData["Message"] = "Deleted successfully";
            try { _friendServices.Delete(userId, id2); }
            catch (ExceptionHandler e) { TempData["Message"] = e.Message; }

            return RedirectToAction("Friends", "Relationship");
        }

        public IActionResult AddFriend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFriend(string username, int id)
        {
            bool added;
            try { added = _friendServices.AddFriend(Cookies.GetId(User), id); }
            catch (ExceptionHandler e)
            {
                ViewData["Message"] = e.Message;
                return View();
            }

            if (added)
                TempData["Message"] = "Succesfully send request";
            else
                TempData["Message"] = "Failed to send friend request";

            return RedirectToAction("Profile", "Account", new { usr = username });
        }

        public IActionResult Requests()
        {
            var requests = new RequestsViewModel();

            try { requests.RelationshipViewModelsPending = RelationshipDicToList(_friendServices.GetPending(Cookies.GetId(User))); }
            catch (ExceptionHandler e) { ViewData["Message1"] = e.Message; }
            try { requests.RelationshipViewModelsSended = RelationshipDicToList(_friendServices.GetSended(Cookies.GetId(User))); }
            catch (ExceptionHandler e) { ViewData["Message2"] = e.Message; }

            return View(requests);
        }

        [HttpPost]
        public IActionResult Requests(int id1, int id2, int type)
        {
            var userId = Cookies.GetId(User);

            // Checks if id2 is the userId.
            if ((id1 != userId) && (id1 != 0))
                id2 = id1;

            // Switch between Accept or Delete.
            switch (type)
            {
                case 1:
                    TempData["Message"] = "Accepted successfully";
                    try { _friendServices.SetAccept(userId, id2); }
                    catch (ExceptionHandler e) { TempData["Message"] = e.Message; }
                    break;
                case 2:
                    TempData["Message"] = "Deleted successfully";
                    try { _friendServices.Delete(userId, id2); }
                    catch (ExceptionHandler e) { TempData["Message"] = e.Message; }
                    break;
                default:
                    TempData["Message"] = "No valid type given";
                    break;
            }

            return RedirectToAction("Requests", "Relationship");
        }

        /// <summary>
        /// Converts given relationship dictionary to List of RelationshipViewModels.
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