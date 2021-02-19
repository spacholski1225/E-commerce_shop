using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace Shop.Controllers
{
    public class EbookController : Controller
    {
        private readonly IEbookRepository _ebookRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ShopDbContext context;

        // private readonly IHostingEnvironment _hostingEnvironment;

        public EbookController(IEbookRepository ebookRepository, IWebHostEnvironment hostingEnvironment, ShopDbContext context)
        {
            _ebookRepository = ebookRepository;
            _hostingEnvironment = hostingEnvironment;
            this.context = context;
        }

        //TO DO naprawidz mechanizm wyswietlania sie wszystkich ebookow po przejsciu na liste
        public ViewResult List()
        {
            var ebooks = context.Ebooks.
            return View(ebooks);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEbookViewModel ebookModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if(ebookModel.Photo != null)
                {
                    //combile two strings to get path to wwwroot
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + ebookModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    ebookModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var ebook = new Ebook
                {
                    Title = ebookModel.Title,
                    Description = ebookModel.Description,
                    Price = ebookModel.Price,
                    Category = ebookModel.Category,
                    PhotoPath = uniqueFileName
                };
                _ebookRepository.Add(ebook);
            }
            return RedirectToAction("List", "Ebook");
        }
    }
}
