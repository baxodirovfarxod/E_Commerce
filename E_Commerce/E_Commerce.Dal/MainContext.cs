using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Dal;

public class MainContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Card> Cards { get; set; }

    public MainContext(DbContextOptions<MainContext> options)
         : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
        modelBuilder.Entity<Product>().ToTable(nameof(Product));
        modelBuilder.Entity<Cart>().ToTable(nameof(Cart));
        modelBuilder.Entity<Order>().ToTable(nameof(Order));
        modelBuilder.Entity<Payment>().ToTable(nameof(Payment));
        modelBuilder.Entity<Card>().ToTable(nameof(Card));

        modelBuilder.Entity<CartProduct>().ToTable(nameof(CartProduct));
        modelBuilder.Entity<CartProduct>()
            .HasKey(cp => new { cp.CartId, cp.ProductId });


        modelBuilder.Entity<OrderProduct>().ToTable(nameof(OrderProduct));
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });
    }

}


