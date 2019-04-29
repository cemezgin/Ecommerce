using System;
using System.Collections.Generic;
using ECommerce.Models;

namespace ECommerce.Repository {
    public interface IProductRepository
    {
        Product Get(CartItem item);
        List<Product> Get();
        void Insert(Product product);
        void Save();
    }
}