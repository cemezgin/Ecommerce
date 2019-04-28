using System.Linq;
using ECommerce.Models;

namespace ECommerce.Services
{
    public class FeedProduct {
        private IProductContext _context;

        public FeedProduct(IProductContext context)
        {
            _context = context;
            if (_context.Products.Count() == 0) {
                Save();
            }
        }

        private void AddProduct() {
           _context.Products.Add(new Product {Id = 1, Name="Gül", Price=10.1, Stock = 5});
           _context.Products.Add(new Product {Id = 2, Name="Lale", Price=8.5, Stock = 5});
           _context.Products.Add(new Product {Id = 3, Name="Orkide", Price=40.8, Stock = 5});
           _context.Products.Add(new Product {Id = 4, Name="Papatya", Price=7.1, Stock = 5});
           _context.Products.Add(new Product {Id = 5, Name="Bonsai", Price=50.5, Stock = 5});
           _context.Products.Add(new Product {Id = 6, Name="Çikolata", Price=20.1, Stock = 5});
        }
        
         private void Save() {
            AddProduct();
            _context.SaveChanges();
        }
    }
}