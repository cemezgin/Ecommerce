using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ECommerce.Models;
using ECommerce.Data;

namespace ECommerce.Repository {
    public class ProductRepostitory : IProductRepository {
        private readonly ProductContext productContext;

        public ProductRepostitory(ProductContext context) {
            this.productContext = context;
        }
        public Product Get(CartItem item) => 
            productContext.Products.FirstOrDefault(p => p.Id == item.ProductId);

        public List<Product> Get() => 
            productContext.Products.ToList();

         public void Insert(Product product)
        {
             productContext.Products.Add(product);
        }

         public void Save()
        {
            productContext.SaveChanges();
        }
    }
}