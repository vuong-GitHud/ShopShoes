using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ShopShoes.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShopShoesContextConnection") ?? throw new InvalidOperationException("Connection string 'ShopShoesContextConnection' not found.");

builder.Services.AddDbContext<ShopShoesContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ShopShoesUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShopShoesContext>();

// Add services to the container.


builder.Services.AddControllersWithViews();

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
