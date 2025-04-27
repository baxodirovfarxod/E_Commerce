using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Dal;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options)
         : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    // DbSet'lar keyinchalik qo‘shiladi
}


