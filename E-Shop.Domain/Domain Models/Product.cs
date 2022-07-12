using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Domain_Models
{
    public class Product : BaseEntity
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDesrciption { get; set; }

        [Display(Name = "Product Price")]
        public float ProductPrice { get; set; }

        public int Rating { get; set; }
        public ICollection<ProductsInShoppingCart> ProductsInShoppingCart { get; set; }
    }
}
