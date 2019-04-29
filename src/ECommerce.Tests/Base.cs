using ECommerce.Models;
using System.Collections.Generic;

public class Base {
    public Product GetMockProduct()
    {
        var product = new Product {
            Id = 1,
            Name = "Mock",
            Price = 5.0,
            Stock = 3
        };

        return product;
    }

    public List<CartItem> GetMockCartItem()
    {
        var cartItem = new List<CartItem>() {
            new CartItem {
                    Id = 1,
                    Product = GetMockProduct(),
                    ProductId = 1
                }
        };

        return cartItem;
    }
    public List<ShoppingCart> GetMockShoppingCart() {
     var shoppingCart = new List<ShoppingCart>() {
            new ShoppingCart {
                CartItems = GetMockCartItem(),
                TotalAmount = 5
            }
        };
        return shoppingCart;
    }
}