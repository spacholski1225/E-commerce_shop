using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{

    public class EbookController : Controller
    {
        private readonly IEbookRepository _ebookRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ShopDbContext context;


        public EbookController(IEbookRepository ebookRepository, IWebHostEnvironment hostingEnvironment, ShopDbContext context)
        {
            _ebookRepository = ebookRepository;
            _hostingEnvironment = hostingEnvironment;
            this.context = context;
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateEbookViewModel ebookModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(ebookModel);

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

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {

            var ebook = _ebookRepository.GetEbookById(id);
            if (ebook is null)
            {
                try
                {
                Response.StatusCode = 404;
                }
                catch(Exception e)
                {

                }
                return View("EbookNotFound", id);
            }

            EditEbookViewModel editEbookViewModel = new EditEbookViewModel
            {
                Id = ebook.EbookId,
                Title = ebook.Title,
                Description = ebook.Description,
                Price = ebook.Price,
                Category = ebook.Category,
                ExistingPath = ebook.PhotoPath
            };
            return View(editEbookViewModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditEbookViewModel ebookModel)
        {
            if (ModelState.IsValid)
            {
                Ebook ebook = _ebookRepository.GetEbookById(ebookModel.Id);
                ebook.Title = ebookModel.Title;
                ebook.Description = ebookModel.Description;
                ebook.Price = ebookModel.Price;
                ebook.Category = ebookModel.Category;
                if (ebookModel.Photo != null)
                {
                    if(ebookModel.ExistingPath != null)
                    {
                       var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", ebookModel.ExistingPath);
                        System.IO.File.Delete(filePath);
                    }
                 ebook.PhotoPath = ProcessUploadedFile(ebookModel);
                }

                
                _ebookRepository.Update(ebook);
            }
            return RedirectToAction("List", "Ebook");
        }

        private string ProcessUploadedFile(CreateEbookViewModel ebookModel)
        {
            string uniqueFileName = null;

            if (ebookModel.Photo != null)
            {
                //combile two strings to get path to wwwroot
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + ebookModel.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                ebookModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult List(string sortOrder, string searchString)
        {
            ViewData["LowToHigh"] = String.IsNullOrEmpty(sortOrder) ? "price_asc" : "";
            ViewData["HighToLow"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            ViewData["CurrentSort"] = sortOrder;


            ViewData["CurrentFilter"] = searchString;

            var ebooks = _ebookRepository.GetAllEbooks;

            if(!String.IsNullOrEmpty(searchString))
            {
                ebooks = ebooks.Where(s => s.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "price_asc":
                    ebooks = ebooks.OrderBy(e => e.Price);
                    
                    break;
                case "price_desc":
                    ebooks = ebooks.OrderByDescending(e => e.Price);
                    
                    break;
                default:
                    break;
            }

            return View(ebooks.ToList());
        }

        [HttpGet]
        public ViewResult EducationCategory()
        {
            var ebooks = context.Ebooks.Where(x => x.Category == EEbookCategory.Education);
            return View(ebooks.ToList());
        }
        [HttpGet]
        public ViewResult HistoryCategory()
        {
            var ebooks = context.Ebooks.Where(x => x.Category == EEbookCategory.History);
            return View(ebooks.ToList());
        }
        [HttpGet]
        public ViewResult HorrorCategory()
        {
            var ebooks = context.Ebooks.Where(x => x.Category == EEbookCategory.Horror);
            return View(ebooks.ToList());
        }
        [HttpGet]
        public ViewResult RomanceCategory()
        {
            var ebooks = context.Ebooks.Where(x => x.Category == EEbookCategory.Romance);
            return View(ebooks.ToList());
        }


    }
}
