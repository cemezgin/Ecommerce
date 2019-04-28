using ECommerce.Models;
using System.Collections.Generic;

namespace ECommerce.Services {
    public interface ICartService
    {
        void AddToCart(Product product);  
        List<ShoppingCart> GetShoppingCart();

    }
}