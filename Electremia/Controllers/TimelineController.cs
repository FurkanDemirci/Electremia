using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Electremia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Electremia.Controllers
{
    public class TimelineController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly PostServices _postServices;
        private readonly ProductServices _productServices;
        private readonly PictureServices _pictureServices;
        private readonly LikeServices _likeServices;
        private readonly CommentServices _commentServices;
        private readonly FriendServices _friendServices;

        public TimelineController(IConfiguration config, IHostingEnvironment environment)
        {
            _environment = environment;

            _postServices = new Factory(config).PostService();
            _productServices = new Factory(config).ProductService();
            _pictureServices = new Factory(config).PictureService();
            _likeServices = new Factory(config).LikeService();
            _commentServices = new Factory(config).CommentService();
            _friendServices = new Factory(config).FriendService();
        }

        [Authorize]
        public IActionResult Index()
        {
            var friendsId = new List<int>();
            try { friendsId = _friendServices.GetFriendsId(Cookies.GetId(User)); }
            catch { ViewData["Message"] = "It seems like you have no friend's."; }
            friendsId.Add(Cookies.GetId(User));

            var timeLine = new TimeLineViewmodel
            {
                Posts = _postServices.GetFriendsPosts(friendsId),
                Products = _productServices.GetFriendsProducts(friendsId)
            };

            return View(timeLine);
        }

        public IActionResult Content(int id, int type)
        {
            //TODO Krijg full content binnen met pictures, likes en comments.
            SelectedContentViewModel selected;

            switch (type)
            {
                case 0: // 0 = Post
                    var post = _postServices.GetById(id);
                    selected = new SelectedContentViewModel
                    {
                        Id = post.PostId,
                        UserId = post.UserId,
                        Type = 0,
                        Title = post.Title,
                        Description = post.Description,
                        DateTime = post.DateTime,
                        Likes = _likeServices.GetAll(id, 0),
                        Comments = _commentServices.GetAll(id, 0),
                        Pictures = _pictureServices.GetAll(id, 0)
                    };
                    break;
                case 1: // 1 = Product
                    var product = _productServices.GetById(id);
                    selected = new SelectedContentViewModel
                    {
                        Id = product.ProductId,
                        UserId = product.UserId,
                        Type = 1,
                        Title = product.Title,
                        Description = product.Description,
                        Price = product.Price,
                        DateTime = product.DateTime,
                        Likes = _likeServices.GetAll(id, 1),
                        Comments = _commentServices.GetAll(id, 1),
                        Pictures = _pictureServices.GetAll(id, 1)
                    };
                    break;
                default:
                    selected = new SelectedContentViewModel();
                    break;
            }
            return View(selected);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Like(int id, int type, int isLiked)
        {
            var liked = false;
            var deleted = false;

            if (isLiked == 1)
            {
                try { deleted = _likeServices.Delete(id, Cookies.GetId(User), type); }
                catch (ExceptionHandler e) { TempData["Message"] = e.Message; }
                if (!deleted)
                    ViewData["Message"] = "Could not delete like";
            }
            else
            {
                try { liked = _likeServices.Add(id, Cookies.GetId(User), type); }
                catch (ExceptionHandler e) { TempData["Message"] = e.Message; }
                if (!liked)
                    ViewData["Message"] = "Could not like content";
            }

            return RedirectToAction("Content", "Timeline", new { id, type });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Comment(int id, int type, string comment)
        {
            var commented = false;
            try { commented = _commentServices.Add(id, Cookies.GetId(User), type, comment); }
            catch (ExceptionHandler e) { TempData["Message"] = e.Message; }

            if (!commented)
                TempData["Message"] = "Something went wrong";

            return RedirectToAction("Content", "Timeline", new { id, type });
        }

        [Authorize]
        public IActionResult CreateContent()
        {
            //TODO Creëer alle soorten content (Post en Product) en stuur het op.
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateContent(CreateContentViewModel model)
        {
            var id = -1;
            if (model.PostViewModel != null)
            {
                try { id = _postServices.CreatePost(Cookies.GetId(User), model.PostViewModel.Title, model.PostViewModel.Description); }
                catch (ExceptionHandler e) { ViewData["Message"] = e.Message; }

                if (model.PostViewModel.Picture == null) return View();
                foreach (var formFile in model.PostViewModel.Picture)
                    _pictureServices.AddPicture(new Picture { Id = id, Url = FileUpload(formFile), Type = 0 });
            }
            else if (model.ProductViewModel != null)
            {
                try { id = _productServices.CreateProduct(Cookies.GetId(User), model.ProductViewModel.Title, model.ProductViewModel.Description, model.ProductViewModel.Price); }
                catch (ExceptionHandler e) { ViewData["Message"] = e.Message; }

                if (model.ProductViewModel.Picture == null) return View();
                foreach (var formFile in model.ProductViewModel.Picture)
                    _pictureServices.AddPicture(new Picture { Id = id, Url = FileUpload(formFile), Type = 1 });
            }
            TempData["Message"] = "Content created successfully";
            return RedirectToAction("Index", "Timeline");
        }

        [HttpPost]
        public IActionResult DeleteContent(int id, int type)
        {
            var deleted = false;
            switch (type)
            {
                case 0:
                    try { deleted = _postServices.DeleteById(id); }
                    catch (ExceptionHandler e) { TempData["Message"] = e; }
                    if (deleted)
                        TempData["Message"] = "Successfully deleted post.";
                    break;
                case 1:
                    try { deleted = _productServices.DeleteById(id); }
                    catch (ExceptionHandler e) { TempData["Message"] = e; }
                    if (deleted)
                        TempData["Message"] = "Successfully deleted product.";
                    break;
                default:
                    TempData["Message"] = "No type of content given.";
                    break;
            }

            if (!deleted)
                TempData["Message"] = "Could not delete.";
            return RedirectToAction("Index", "Timeline");
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