using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{code}")]
        public IActionResult NotFound(int code)
        {
            switch (code)
            {
                case 404:
                    ViewBag.ErrorMessage = "Ups, not found :c";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Something wrong :v";
                    break;
            }
            return View();
        }
    }
}
