using System;
using System.Collections.Generic;
using System.Text;
using E_Shop.Domain.Dto;

namespace E_Shop.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShopingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, int productId);
        bool orderNow(string userId);
    }
}
