using Registrator.Models;

namespace Registrator.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cart = new List<CartItem>();

        /// <summary>
        /// Gets the items in the cart.
        /// </summary>
        public List<CartItem> GetCartItems()
        {
            return new List<CartItem>(_cart);
        }

        /// <summary>
        /// Adds a product to the cart or updates its quantity if it already exists.
        /// </summary>
        public void AddToCart(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));

            var cartItem = _cart.Find(ci => ci.Product.Id == product.Id);

            if (cartItem == null)
            {
                _cart.Add(new CartItem(product, quantity));
            }
            else
            {
                UpdateQuantity(product, cartItem.Quantity + quantity);
            }
        }

        /// <summary>
        /// Updates the quantity of a product in the cart.
        /// </summary>
        public void UpdateQuantity(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative", nameof(quantity));

            var cartItem = _cart.Find(ci => ci.Product.Id == product.Id);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
            else
            {
                throw new InvalidOperationException("Product does not exist in the cart");
            }
        }

        /// <summary>
        /// Removes a product from the cart.
        /// </summary>
        public void RemoveFromCart(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var cartItem = _cart.Find(ci => ci.Product.Id == product.Id);

            if (cartItem != null)
            {
                _cart.Remove(cartItem);
            }
        }
    }
}
