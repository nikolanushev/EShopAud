using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Domain_Models
{
    public class ShoppingCart : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ICollection<ProductsInShoppingCart> ProductsInShoppingCart { get; set; }
    }
}
