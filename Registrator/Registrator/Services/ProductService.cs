using Registrator.Models;

namespace Registrator.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 5 },
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 10 },
            new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 20 },
        };

        /// <summary>
        /// Gets all products.
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return new List<Product>(_products);
        }

        /// <summary>
        /// Gets a product by its identifier.
        /// </summary>
        public Product GetProductById(int productId)
        {
            var product = _products.Find(p => p.Id == productId);

            if (product == null)
            {
                throw new ArgumentException("Product with the given id does not exist", nameof(productId));
            }

            return product;
        }
    }
}
