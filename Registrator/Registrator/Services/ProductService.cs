using Registrator.Models;

namespace Registrator.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 5},
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 10},
            new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 20},
        };

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int productId)
        {
            return _products.Find(p => p.Id == productId);
        }
    }
}
