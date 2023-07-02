using Microsoft.AspNetCore.Mvc;
using ShopShoes.Data;
using ShopShoes.Models;
using ShopShoes.Models.EF;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using ShopShoes.Areas.Identity.Data;

namespace ShopShoes.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopShoesContext shopShoesContext;

        public ProductController(ShopShoesContext shopShoesContext)
        {
            this.shopShoesContext = shopShoesContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await shopShoesContext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductViewModel)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = addProductViewModel.Name,
                Price = addProductViewModel.Price,
                Amount = addProductViewModel.Amount,
                DateCreate = addProductViewModel.DateCreate,
                Status = addProductViewModel.Status
            };
            await shopShoesContext.Products.AddAsync(product);
            await shopShoesContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
