using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Ebook Ebook { get; set; }
        public int Amount { get; set; }
        public string ShoppingCardId { get; set; }
    }
}
