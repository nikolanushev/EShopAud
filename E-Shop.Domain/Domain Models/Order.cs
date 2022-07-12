using E_Shop.Domain.Domain_Models;
using E_Shop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Domain_Models
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ShopApplicationUser OrderedBy { get; set; }
        public List<ProductsInOrder> Products { get; set; }
        public int Quantity { get; set; }

    }
}
