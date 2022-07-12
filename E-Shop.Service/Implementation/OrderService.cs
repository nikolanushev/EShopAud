using E_Shop.Domain.Domain_Models;
using E_Shop.Repository.Interface;
using E_Shop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> getAllOrders()
        {
            return _orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return _orderRepository.getOrderDetails(model);
        }
    }
}
