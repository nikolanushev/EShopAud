using E_Shop.Domain.Domain_Models;
using E_Shop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Shop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> getAllOrders()
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.Products).Include("Products.Product").ToList();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities.Include(z => z.OrderedBy).Include(z => z.Products).Include("Products.Product").SingleOrDefault(z => z.Id == model.Id);
        }
    }
}
