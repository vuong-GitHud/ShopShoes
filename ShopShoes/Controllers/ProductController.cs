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

        // GET: Product

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = shopShoesContext.Products.ToList();
            return View(products);
        }

        // GET: Product/Create

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }  
        
        // GET: Product/Create
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (ModelState.IsValid)
            {
                shopShoesContext.Products.Add(product);
                shopShoesContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
