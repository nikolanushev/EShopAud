using E_Shop.Domain.Domain_Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Identity
{
    public class ShopApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserShoppingCart { get; set; }
    }
}
