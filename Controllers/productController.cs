using Microsoft.AspNetCore.Mvc;
using PoeProject.Models;

namespace PoeProject.Controllers
{
    public class productController : Controller
    {
        public productTable prodtbl = new productTable();

        [HttpPost]
        public IActionResult MyWork(productTable product)
        {
            var result2 = prodtbl.insert_product(product);
            return RedirectToAction("MyWork", "Home");
        }

        [HttpGet]
        public IActionResult MyWork()
        {
            ProductService productService = new ProductService();
            List<productTable> products = productService.GetAllProducts();

            return View(products);
        }
    }
}