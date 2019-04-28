
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Services
{
    public class CartService : ICartService
    {        
        private readonly ICartItemContext _context;

        public CartService (ICartItemContext context) 
        {
            _context = context;
        }
        
        public List<ShoppingCart> ShoppingCart { get; set; }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = _context.CartItems.Include(s => s.Product).SingleOrDefault(
                s => s.Product.Id == product.Id
            );

            if (shoppingCartItem == null) {
                shoppingCartItem = new CartItem {Product = product};
                _context.CartItems.Add(shoppingCartItem);
            } else {
                shoppingCartItem.Quantity++;
            }

            if (IsInStock(shoppingCartItem.Product)) {
                shoppingCartItem.Product.Stock--;
                _context.SaveChanges();
            }
        }

        public List<CartItem> GetShoppingCartItems() =>
             _context.CartItems.Include(s => s.Product).ToList();

         double GetShoppingCartTotalAmount() => 
            _context.CartItems.Select(c => c.Product.Price * c.Quantity).Sum();

        private bool IsInStock(Product product) => product.Stock == 0 ? false : true;

        public List<ShoppingCart> GetShoppingCart() {
            List<ShoppingCart> Cart =  new List<ShoppingCart>() {
                new ShoppingCart() {
                    CartItems = GetShoppingCartItems(),
                    TotalAmount = GetShoppingCartTotalAmount()
                }
            };

            return Cart;
        }
    }
}