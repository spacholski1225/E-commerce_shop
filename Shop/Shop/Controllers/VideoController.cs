using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models.Interfaces;
using Shop.Models.Videos;
using Shop.ViewModels;
using System;
using System.IO;

namespace Shop.Controllers
{
    public class VideoController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ShopDbContext context;
        private readonly IVideoRepository videoRepository;

        public VideoController(IWebHostEnvironment hostingEnvironment, ShopDbContext context, IVideoRepository videoRepository)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
            this.videoRepository = videoRepository;
        }
        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateVideoViewModel videoModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(videoModel);

                var video = new Video
                {
                    Title = videoModel.Title,
                    Description = videoModel.Description,
                    Price = videoModel.Price,
                    Category = videoModel.Category,
                    PhotoPath = uniqueFileName
                };
                videoRepository.Add(video);
            }
            return RedirectToAction("List", "Ebook");
        }
        private string ProcessUploadedFile(CreateVideoViewModel videoModel)
        {
            string uniqueFileName = null;

            if (videoModel.Photo != null)
            {
                //combile two strings to get path to wwwroot
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + videoModel.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                videoModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }
    }
}
