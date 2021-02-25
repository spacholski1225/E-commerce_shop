using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
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
            return View();
        }
    }
}
