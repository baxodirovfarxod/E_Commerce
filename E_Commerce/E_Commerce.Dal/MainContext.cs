using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Dal;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options)
      : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
    }

}


