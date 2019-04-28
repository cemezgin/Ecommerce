using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        
        public CartController(
            IProductService productService,
            ICartService cartService
        ) {
            _productService = productService;
            _cartService = cartService;
        }

        //  GET: api/Cart
        [HttpGet]
        public ActionResult<List<CartItem>> GetCartItems()
        {
            return Ok(_cartService.GetShoppingCart());
        }

        // POST: api/Cart
        [HttpPost]
        public ActionResult PostCartItem([Bind("ProductId")] CartItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var selectedProduct = _productService.Get(item);
            if (selectedProduct != null) {
                _cartService.AddToCart(selectedProduct);
            }

            return RedirectToAction("GetCartItems");
        }
    }
}