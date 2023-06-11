using Microsoft.AspNetCore.Mvc;
using Registrator.Services;

namespace Registrator.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            ViewBag.Products = products;

            return View(_cartService.GetCartItems());
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            _cartService.AddToCart(product, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            _cartService.UpdateQuantity(product, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            _cartService.RemoveFromCart(product);

            return RedirectToAction("Index");
        }
    }
}
