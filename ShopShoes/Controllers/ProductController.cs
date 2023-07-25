using Microsoft.AspNetCore.Mvc;
using ShopShoes.Data;
using ShopShoes.Models;
using ShopShoes.Models.EF;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
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
            //return View(await shopShoesContext.Products.ToListAsync());

        }

        // GET: Product/Create

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // GET: Product/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]

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
        //public async Task<IActionResult> Edit1(Guid id)
        //{
        //    var product = await shopShoesContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        //    if (product != null)
        //    {
        //        var viewModel = new UpdateProductViewModel();
        //        Id = product.Id,
        //        Name = product.Name,
        //        Price = product.Price,
        //        Amount = product.Amount,
        //        DateCreate = product.DateCreate,
        //        Status = product.Status


        //    };
        //}
        //GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = shopShoesContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Guid? id, /*[Bind("Id,Name,Price,Amount,DateCreate,Status")]*/ Product product)
        {

            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    shopShoesContext.Update(product);
                    await shopShoesContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");


            }
            return View(product);
        }

        private bool ProductExists(Guid id)
        {
            return shopShoesContext.Products.Any(x => x.Id == id);
        }
    }
}
