using Microsoft.AspNetCore.Mvc;
using QHRM.Models;
using QHRM.Services;

namespace QHRM.Controllers
{
    public class ProductsController : Controller
        
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment) 
        {
        this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            //save the product in database
            Product products = new Product()
            {
                Name = product.Name,
                price = product.price,
                Description = product.Description,
                CreatedAt = DateTime.Now,
            };

            context.Products.Add(products);
            context.SaveChanges();

            return RedirectToAction("Index","Products");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if(product == null)
            {
                return RedirectToAction("Index", "Products");
            }
            var products = new Product()
            {
                Name = product.Name,
                price = product.price,
                Description = product.Description,

            };
            ViewData["ProductId"] = product.Id;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");


            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id,Product product)
        {
            var products = context.Products.Find(id);
            if(products == null)
            {
                return RedirectToAction("Index", "Products");
            }

            if(!ModelState.IsValid)
            {
                ViewData["ProductId"] = product.Id;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

                return View(product);
            }

            //update the product in database
            products.Name = product.Name;
            products.Description = product.Description;
            products.price = product.price;

            context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            {
                if(product == null)
                {
                    return RedirectToAction("Index", "Products");
                }

                context.Products.Remove(product);
                context.SaveChanges(true);

                return RedirectToAction("Index", "Products");
            }
        }

    }
}
