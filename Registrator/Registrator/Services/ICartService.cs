using Registrator.Models;

namespace Registrator.Services
{
    public interface ICartService
    {
        List<CartItem> GetCartItems();
        void AddToCart(Product product, int quantity);
        void UpdateQuantity(Product product, int quantity);
        void RemoveFromCart(Product product);
    }
}
