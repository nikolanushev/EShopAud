using E_Shop.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Domain.Dto
{
    public class AddToShoppingCartDto
    {
        public Product SelectedProduct { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
