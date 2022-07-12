using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Domain_Models
{
    public class ProductsInShoppingCart : BaseEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }

        [ForeignKey("ProductId")]
        public Product Products { get; set; }

        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
