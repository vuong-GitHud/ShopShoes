using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopShoes.Areas.Identity.Data;
using ShopShoes.Entity;
using Shopshose.Data.Entity;

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
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Oder> Oders { get; set; }



}
