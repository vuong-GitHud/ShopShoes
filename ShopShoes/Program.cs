using Microsoft.EntityFrameworkCore;
using ShopShoes.Areas.Identity.Data;
using ShopShoes.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShopShoesContextConnection") ?? throw new InvalidOperationException("Connection string 'ShopShoesContextConnection' not found.");

builder.Services.AddDbContext<ShopShoesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopShoesContextConnection")));

builder.Services.AddDefaultIdentity<ShopShoesUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ShopShoesContext>();

// Add services to the container.

builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ShopShoesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopShoesContextConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
