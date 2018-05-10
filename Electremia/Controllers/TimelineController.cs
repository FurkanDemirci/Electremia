using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Electremia.Logic;
using Electremia.Logic.Services;
using Electremia.Model.Models;
using Electremia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Electremia.Controllers
{
    public class TimelineController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly PostServices _postServices;
        private readonly ProductServices _productServices;
        private readonly PictureServices _pictureServices;

        public TimelineController(IConfiguration config, IHostingEnvironment environment)
        {
            _environment = environment;

            _postServices = new Factory(config).PostService();
            _productServices = new Factory(config).ProductService();
            _pictureServices = new Factory(config).PictureService();
        }

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
                    _pictureServices.AddPicture(new Picture { Id = id, Url = FileUpload(formFile), Type = 0});
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