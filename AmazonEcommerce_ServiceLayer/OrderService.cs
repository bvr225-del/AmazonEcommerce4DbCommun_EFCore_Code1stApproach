using AmazonEcommerce_BusinessEntities.Dtos;
using AmazonEcommerce_BusinessEntities.Entities;
using AmazonEcommerce_BusinessEntities.Interfaces;
using AmazonEcommerce_DbConnectivity.Migrations.Order;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_ServiceLayer
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            this._mapper = mapper;
        }
        public async Task<int> AddOrder(OrderDto orderdetail)
        {
            Order order = new Order();
            _mapper.Map(orderdetail, order);
            var res = await _orderRepository.AddOrder(order);
            return res;

        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _orderRepository.DeleteOrderById(orderid);
            return true;

        }

        public async Task<OrderDto> GetOrderById(int orderid)
        {
            var res = await _orderRepository.GetOrderById(orderid);
            return _mapper.Map<OrderDto>(res);

        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var res = await _orderRepository.GetOrders();
            return _mapper.Map<List<OrderDto>>(res);

        }

        public async Task<bool> UpdateOrder(OrderDto orderdetail)
        {
            Order obj = new Order();
            _mapper.Map(orderdetail, obj);
            await _orderRepository.UpdateOrder(obj);
            return true;

        }
    }
}
