using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShoppingCart
    {
        private readonly ShopDbContext _context;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ShopDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ShopDbContext>();
            var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Ebook ebook, int amount)
        {
            var shoppingCartItem = _context.ShoppingClassItems.SingleOrDefault(s => s.Ebook.EbookId == ebook.EbookId
                                                                               && s.ShoppingCardId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCardId = ShoppingCartId,
                    Ebook = ebook,
                    Amount = 1
                };
                _context.ShoppingClassItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Ebook ebook)
        {
            var shoppingCartItem = _context.ShoppingClassItems.SingleOrDefault(
                s => s.Ebook.EbookId == ebook.EbookId && s.ShoppingCardId == ShoppingCartId);

            var localAmount = 0;

            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingClassItems.Remove(shoppingCartItem);
                }

            }
            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingClassItems.Where(c => c.ShoppingCardId == ShoppingCartId)
                                        .Include(x => x.Ebook).ToList());
        }
        
        public void ClearCart()
        {
            var cartItems = _context.ShoppingClassItems.Where(c => c.ShoppingCardId == ShoppingCartId);
            _context.ShoppingClassItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingClassItems.Where(c => c.ShoppingCardId == ShoppingCartId).Select(s => s.Ebook.Price * s.Amount).Sum();
            return total;
        }
    }
}
