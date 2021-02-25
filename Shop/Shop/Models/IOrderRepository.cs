using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
