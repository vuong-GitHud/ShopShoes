using Microsoft.AspNetCore.Mvc;
using ShopShoes.Data;
using ShopShoes.Models;
using ShopShoes.Models.EF;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using ShopShoes.Areas.Identity.Data;
using Microsoft.Build.Framework;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Hosting;
using System.IO;

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

        // Post: Product/Create
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductViewModel, IFormFile imageFile)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = addProductViewModel.Name,
                Price = addProductViewModel.Price,
                Amount = addProductViewModel.Amount,
                DateCreate = addProductViewModel.DateCreate,
                Status = addProductViewModel.Status,


            };
            if (imageFile != null && imageFile.Length > 0)
            {
                // Save the image file to a folder on the server and set the ImageFileName property
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                product.ImageFileName = fileName;
            }
            await shopShoesContext.Products.AddAsync(product);
            await shopShoesContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public IActionResult GetImage(Guid id)
        //{
        //    var product = shopShoesContext.Products.Find(id);
        //    if (product != null)
        //    {
        //        var imagePath = product.ImageFileName;
        //        var imageFileStream = new FileStream("wwwroot" + imagePath, FileMode.Open);
        //        return File(imageFileStream, "image/jpeg");
        //    }
        //    return NotFound();
        //GET: Product/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = shopShoesContext.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                var viewModel = new UpdateProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Amount = product.Amount,
                    DateCreate = product.DateCreate,
                    Status = product.Status,
                    ImageFileName = product.ImageFileName
                };
                return await Task.Run(() => View("Edit", viewModel));

            }
            return RedirectToAction("Index");
        }
        // Post: Product/Edit

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductViewModel model)
        {
            var product = await shopShoesContext.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Amount = model.Amount;
                product.DateCreate = model.DateCreate;
                product.Status = model.Status;
                //product.ImageFileName = model.ImageFileName;

                await shopShoesContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        // Post: Product/Delete

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await shopShoesContext.Products.FindAsync(id);
            if (product != null)
            {
                shopShoesContext.Products.Remove(product);
                await shopShoesContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await shopShoesContext.Products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var product = await shopShoesContext.Products.FindAsync(id);
        //    shopShoesContext.Products.Remove(product);
        //    await shopShoesContext.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
