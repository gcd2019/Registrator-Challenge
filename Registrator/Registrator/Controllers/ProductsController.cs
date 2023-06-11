using Microsoft.AspNetCore.Mvc;
using Registrator.Services;

namespace Registrator.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
    }
}