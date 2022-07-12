using E_Shop.Domain.Domain_Models;
using E_Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Shop.Service.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetDetailsForProduct(int id);
        void CreateNewProduct(Product p);
        void UpdateExistingProduct(Product p);
        ShoppingCartDto GetShoppingCartInfo(int id);
        void DeleteProduct(int id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
