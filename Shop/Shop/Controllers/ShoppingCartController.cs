using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IEbookRepository _ebookRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IEbookRepository ebookRepository, ShoppingCart shoppingCart)
        {
            _ebookRepository = ebookRepository;
            _shoppingCart = shoppingCart;
        }

        public IEbookRepository EbookRepository { get; }
        public ShoppingCart ShoppingCart { get; }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingVM);
        }
        public RedirectToActionResult AddToShoppingCart(int ebookId)
        {
            var selectedEbook = _ebookRepository.GetEbookById(ebookId);
            if(selectedEbook != null)
            {
                _shoppingCart.AddToCart(selectedEbook, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int ebookId)
        {
            var selectedEbook = _ebookRepository.GetEbookById(ebookId);
            if (selectedEbook != null)
            {
                _shoppingCart.RemoveFromCart(selectedEbook);
            }
            return RedirectToAction("Index");
        }
    }
}
