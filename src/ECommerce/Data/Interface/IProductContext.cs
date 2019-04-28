using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

public interface IProductContext {
    DbSet<Product> Products { get; set; }
    int SaveChanges();

}