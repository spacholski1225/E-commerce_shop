using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ShopDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.dateTime = DateTime.Now;
            _context.Orders.Add(order);

            var shoppingCartItems = _context.ShoppingClassItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    EbookId = item.Ebook.EbookId,
                    OrderId = order.OrderId,
                    Price = item.Ebook.Price

                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
