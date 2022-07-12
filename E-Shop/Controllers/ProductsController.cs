using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using E_Shop.Service.Interface;
using E_Shop.Domain.Dto;
using E_Shop.Domain.Domain_Models;
using Microsoft.Extensions.Logging;

namespace E_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(_productService.GetAllProducts());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(new List<Product>());
            }   
        }

        // GET: Adding To Cart Form
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = _productService.GetDetailsForProduct(productId);
            var model = new AddToShoppingCartDto();
            model.SelectedProduct = product;
            model.ProductId = product.Id;
            model.Quantity = 0;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(AddToShoppingCartDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = this._productService.AddToShoppingCart(model, userId);
            if(result)
            {
                return RedirectToAction("Index", "Products");
            }
            return RedirectToAction("Index");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var product = _productService.GetDetailsForProduct(id??0);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateNewProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetDetailsForProduct(id??0);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.UpdateExistingProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetDetailsForProduct(id ?? 0);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _productService.GetDetailsForProduct(id) != null;
        }
    }
}
