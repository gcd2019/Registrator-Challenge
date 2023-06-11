using Microsoft.AspNetCore.Mvc;
using Registrator.Models;

namespace Registrator.Controllers
{
    public class ProductsController : Controller
    {
        // This should be replaced by an actual database in a real-world app
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10},
        };

        public ActionResult Index()
        {
            return View(_products);
        }

        public static Product GetProductById(int productId)
        {
            return _products.Find(p => p.Id == productId);
        }
    }
}
