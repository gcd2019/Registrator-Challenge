using Registrator.Models;

namespace Registrator.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cart = new List<CartItem>();

        public List<CartItem> GetCartItems()
        {
            return _cart;
        }

        public void AddToCart(Product product, int quantity)
        {
            var cartItem = _cart.Find(ci => ci.Product.Id == product.Id);

            if (cartItem == null)
            {
                _cart.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void UpdateQuantity(Product product, int quantity)
        {
            var cartItem = _cart.Find(ci => ci.Product.Id == product.Id);

            if (cartItem != null && quantity >= 0)
            {
                cartItem.Quantity = quantity;
            }
        }

        public void RemoveFromCart(Product product)
        {
            var cartItem = _cart.Find(ci => ci.Product.Id == product.Id);

            if (cartItem != null)
            {
                _cart.Remove(cartItem);
            }
        }
    }
}
