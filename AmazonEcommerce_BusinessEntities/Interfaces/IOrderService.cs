using AmazonEcommerce_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrderDto orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(OrderDto orderdetail);

    }
}
