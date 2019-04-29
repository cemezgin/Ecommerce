
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.Repository;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {        
        private readonly IProductRepository repository;
        public ProductService (IProductRepository repository) 
        {
            this.repository = repository;
            new FeedProduct(repository);
        }

        public Product Get(CartItem item) => 
             this.repository.Get(item);
        
        public void Insert(Product product)
        {
             this.repository.Insert(product);
        }
    }
}