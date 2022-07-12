using E_Shop.Domain.Domain_Models;
using E_Shop.Domain.Dto;
using E_Shop.Repository.Interface;
using E_Shop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Shop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IUserRepository _userRepository;
        public readonly IRepository<ProductsInOrder> _productsInOrderRepository;
        public readonly IRepository<ShoppingCart> _shoppingCartRepository;
        public readonly IRepository<Order> _orderRepository;
        public ShoppingCartService(IUserRepository userRepository, 
                IRepository<ProductsInOrder> productsInOrderRepository,
                IRepository<ShoppingCart> shoppingCartRepository,
                IRepository<Order> orderRepository)
        {
            _userRepository = userRepository;
            _productsInOrderRepository = productsInOrderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
        }

        public bool deleteProductFromShoppingCart(string userId, int productId)
        {
            if(!string.IsNullOrEmpty(userId) && productId != null)
            {
                var loggInUser = _userRepository.Get(userId);
                var userShoppingCart = loggInUser.UserShoppingCart;
                var itemToDelete = userShoppingCart.ProductsInShoppingCart.Where(z => z.ProductId == productId).FirstOrDefault();
                userShoppingCart.ProductsInShoppingCart.Remove(itemToDelete);
                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ShoppingCartDto getShopingCartInfo(string userId)
        {
            var user = _userRepository.Get(userId);
            var userShoppingCart = user.UserShoppingCart;

            var productList = userShoppingCart.ProductsInShoppingCart.Select(z => new
            {
                Quantity = z.Quantity,
                ProductPrice = z.Products.ProductPrice
            });
            float totalPrice = 0;
            foreach (var item in productList)
            {
                totalPrice += item.ProductPrice * item.Quantity;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TotalPrice = totalPrice,
                ProductsInShoppingCart = userShoppingCart.ProductsInShoppingCart.ToList()
            };

            return model;
        }

        public bool orderNow(string userId)
        {
            var user = _userRepository.Get(userId);
            var userShoppingCart = user.UserShoppingCart;

            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user
            };
            _orderRepository.Insert(newOrder);

            List<ProductsInOrder> productsInOrder = userShoppingCart.ProductsInShoppingCart.Select(z => new ProductsInOrder
            {
                Product = z.Products,
                ProductId = z.ProductId,
                Order = newOrder,
                OrderId = newOrder.Id,
                Quantity = z.Quantity
            }).ToList();

            foreach (var item in productsInOrder)
            {
                _productsInOrderRepository.Insert(item);
            }
            user.UserShoppingCart.ProductsInShoppingCart.Clear();
            _userRepository.Update(user);

            return true;
        }
    }
}
