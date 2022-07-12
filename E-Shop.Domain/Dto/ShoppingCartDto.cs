using E_Shop.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Dto
{
    public class ShoppingCartDto
    {
        public List<ProductsInShoppingCart> ProductsInShoppingCart { get; set; }
        public float TotalPrice { get; set; }
    }
}
