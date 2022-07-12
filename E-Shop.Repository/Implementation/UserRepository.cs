using E_Shop.Domain.Identity;
using E_Shop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Shop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShopApplicationUser>();
        }

        public ShopApplicationUser Get(string id)
        {
            var user = entities.Include(z => z.UserShoppingCart).
                Include("UserShoppingCart.ProductsInShoppingCart").
                Include("UserShoppingCart.ProductsInShoppingCart.Products").
                SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }
            return user;
        }

        public IEnumerable<ShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ShopApplicationUser entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
