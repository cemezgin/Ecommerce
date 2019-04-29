using System;
using System.Collections.Generic;
using ECommerce.Models;

namespace ECommerce.Repository {
    public interface ICartItemRepository
    {
        void AddToCart(Product product);
        List<CartItem> GetShoppingCartItems();
        double GetShoppingCartTotalAmount();
    }
}