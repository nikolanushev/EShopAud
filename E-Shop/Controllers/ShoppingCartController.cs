using E_Shop.Domain.Domain_Models;
using E_Shop.Domain.Dto;
using E_Shop.Repository;
using E_Shop.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var model = _shoppingCartService.getShopingCartInfo(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(int id)
        {
            _shoppingCartService.deleteProductFromShoppingCart(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return RedirectToAction("Index");
        }

        public IActionResult OrderNow()
        {
            _shoppingCartService.orderNow(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction(nameof(Index));
        }
    }
}

