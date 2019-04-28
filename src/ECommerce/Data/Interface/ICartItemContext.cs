using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

public interface ICartItemContext {
    DbSet<CartItem> CartItems { get; set; }
    int SaveChanges();

}