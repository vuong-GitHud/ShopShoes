using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopShoes.Models.EF;

namespace ShopShoes.Data;

public class ShopShoesContext : IdentityDbContext<ShopShoesUser>
{
    public ShopShoesContext(DbContextOptions<ShopShoesContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categoris { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Oder> Oders { get; set; }



}
