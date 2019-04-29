using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ECommerce.Models;
using ECommerce.Data;

namespace ECommerce.Repository {
    public class CartItemRepository : ICartItemRepository {
        private readonly CartItemContext cartItemContext;

        public CartItemRepository(CartItemContext cartItemContext)
        {
            this.cartItemContext = cartItemContext;
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = cartItemContext.CartItems.Include(s => s.Product).SingleOrDefault(
                s => s.Product.Id == product.Id
            );

            if (shoppingCartItem == null) {
                shoppingCartItem = new CartItem {Product = product};
                cartItemContext.CartItems.Add(shoppingCartItem);
            } else {
                shoppingCartItem.Quantity++;
            }

            if (IsInStock(shoppingCartItem.Product)) {
                shoppingCartItem.Product.Stock--;
                cartItemContext.SaveChanges();
            }
        }

        public List<CartItem> GetShoppingCartItems() =>
             cartItemContext.CartItems.Include(s => s.Product).ToList();

         public double GetShoppingCartTotalAmount() => 
            cartItemContext.CartItems.Select(c => c.Product.Price * c.Quantity).Sum();

        private bool IsInStock(Product product) => product.Stock == 0 ? false : true;
    }
}