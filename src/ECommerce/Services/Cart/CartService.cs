
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Repository;
using ECommerce.Models;

namespace ECommerce.Services
{
    public class CartService : ICartService
    {        
        private readonly ICartItemRepository repository;

        public CartService (ICartItemRepository repository) 
        {
            this.repository = repository;
        }
        
        public List<ShoppingCart> ShoppingCart { get; set; }

        public void AddToCart(Product product)
        {
            this.repository.AddToCart(product);
        }

        private bool IsInStock(Product product) => product.Stock == 0 ? false : true;

        public List<ShoppingCart> GetShoppingCart() {
            List<ShoppingCart> Cart =  new List<ShoppingCart>() {
                new ShoppingCart() {
                    CartItems = this.repository.GetShoppingCartItems(),
                    TotalAmount = this.repository.GetShoppingCartTotalAmount()
                }
            };

            return Cart;
        }
    }
}