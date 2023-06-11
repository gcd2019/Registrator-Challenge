using Microsoft.AspNetCore.Mvc;
using Registrator.Models;

namespace Registrator.Controllers
{
    public class CartController : Controller
    {
        private static List<CartItem> _cart = new List<CartItem>();

        public ActionResult Index()
        {
            // Fetch the list of products
            var products = ProductsController.GetAllProducts();

            // Assign the products to ViewBag.Products
            ViewBag.Products = products;

            return View(_cart);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = ProductsController.GetProductById(productId);
            var cartItem = _cart.Find(ci => ci.Product.Id == productId);

            if (cartItem == null)
            {
                _cart.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int productId, int quantity)
        {
            var cartItem = _cart.Find(ci => ci.Product.Id == productId);

            if (cartItem != null && quantity >= 0)
            {
                cartItem.Quantity = quantity;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int productId)
        {
            var cartItem = _cart.Find(ci => ci.Product.Id == productId);

            if (cartItem != null)
            {
                _cart.Remove(cartItem);
            }

            return RedirectToAction("Index");
        }
    }
}
