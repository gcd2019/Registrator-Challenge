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
            try
            {
                var product = _productService.GetProductById(productId);
                _cartService.AddToCart(product, quantity);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            try
            {
                var product = _productService.GetProductById(productId);
                _cartService.UpdateQuantity(product, quantity);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            try
            {
                var product = _productService.GetProductById(productId);
                _cartService.RemoveFromCart(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
