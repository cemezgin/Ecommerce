using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Data
{
    public class CartItemContext : DbContext, ICartItemContext
    {
        public CartItemContext(DbContextOptions<CartItemContext> options): base(options)
        {
        }
        
        public DbSet<CartItem> CartItems { get; set; }
    }
}