using E_Shop.Domain.Domain_Models;
using E_Shop.Domain.Dto;
using E_Shop.Repository.Interface;
using E_Shop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Shop.Service.Implementation
{
    public class ProductService : IProductService
    {
        public readonly IRepository<Product> _productRepository;
        public readonly IRepository<ProductsInShoppingCart> _productsInShoppingCartRepository;
        public readonly IUserRepository _userRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductsInShoppingCart> productsInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _productsInShoppingCartRepository = productsInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserShoppingCart;

            if (userShoppingCard != null)
            {
                var product = this.GetDetailsForProduct(item.ProductId);

                if (product != null)
                {
                    ProductsInShoppingCart itemToAdd = new ProductsInShoppingCart
                    {
                        Products = product,
                        ProductId = product.Id,
                        ShoppingCart = userShoppingCard,
                        CartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    _productsInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewProduct(Product p)
        {
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.Get(id);
            this._productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetDetailsForProduct(int id)
        {
            return _productRepository.Get(id);
        }

        public ShoppingCartDto GetShoppingCartInfo(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }
    }
}
