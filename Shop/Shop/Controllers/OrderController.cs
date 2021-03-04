using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shopping;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shopping)
        {
            _shopping = shopping;
            _orderRepository = orderRepository;
        }
        public IActionResult Checkout()
        {
            if (_shopping.GetShoppingCartTotal() != 0)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Cart is empty";
            ViewBag.ErrorMessage = "Please add something";
            return View("NotFound");
        }
    }
}
