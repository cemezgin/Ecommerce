using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Data
{
    public class ProductContext : DbContext,IProductContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
    }
}