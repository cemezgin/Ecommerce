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
    [Route("api/[controller]s")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;
        
        public CartController(
            IProductService productService,
            ICartService cartService
        ) {
            this.productService = productService;
            this.cartService = cartService;
        }

        //  GET: api/carts
        [HttpGet]
        public ActionResult<List<CartItem>> GetCartItems()
        {
            return Ok(this.cartService.GetShoppingCart());
        }

        // POST: api/carts
        [HttpPost]
        public ActionResult PostCartItem([Bind("ProductId")] CartItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var selectedProduct = this.productService.Get(item);
            if (selectedProduct != null) {
                this.cartService.AddToCart(selectedProduct);
            }

            return CreatedAtAction("GetCartItems", this.cartService.GetShoppingCart());
        }
    }
}