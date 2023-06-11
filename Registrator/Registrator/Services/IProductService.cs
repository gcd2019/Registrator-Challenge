using Registrator.Models;

namespace Registrator.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
    }
}
