using E_Shop.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Service.Interface
{
    public interface IOrderService
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);
    }
}
