
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {        
        private readonly IProductContext _context;
        public ProductService (IProductContext context) 
        {
            _context = context;
            new FeedProduct(context);
        }

        public Product Get(CartItem item) => 
            _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
    }
}