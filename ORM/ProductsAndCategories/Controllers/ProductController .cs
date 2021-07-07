using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers
{
    public class ProductController  : Controller
    {
        private MyContext dbContext;
        public ProductController(MyContext context)
        {

            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllProducts = dbContext.Products;
            return View();
        }
        [HttpGet("{productId}")]
        public IActionResult Show(int productId)
        {
            var product = dbContext.Products
                .Include(p => p.Associations)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(p => p.ProductId == productId);
               
            var CategoryNotInProd = dbContext.Categories
                .Include(p => p.Associations)
                .Where(p => p.Associations.All(a => a.ProductId != productId));

            ViewBag.Categories = CategoryNotInProd;
            return View(product);
        }
        [HttpPost("create")]
        public IActionResult Create(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();
            }
            ViewBag.AllProducts = dbContext.Products;
            return View("Index");
        }

        [HttpPost("AddCatToProd")]
        public IActionResult AddCategoryToProduct(Association newAssoc)
        {
           
            dbContext.Associations.Add(newAssoc);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    }

