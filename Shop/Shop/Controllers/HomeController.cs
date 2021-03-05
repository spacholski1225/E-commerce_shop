using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            var from = model.Email;
            MailMessage message = new MailMessage(from, "spacholski1225@gmail.com");
            message.Subject = "Contact from ecommerce" + model.FirstName + ", " + model.LastName + ": " + model.Email;
            message.Body = model.Message;
            //there should by stmp config
            string email = message.Subject + " | " + message.Body;
            _logger.Log(LogLevel.Warning, email);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
