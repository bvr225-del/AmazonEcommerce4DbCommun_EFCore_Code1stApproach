using AmazonEcommerce_BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int orderid);
        Task<int> AddOrder(Order orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(Order orderdetail);

    }
}
