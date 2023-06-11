using System.ComponentModel.DataAnnotations;

namespace Registrator.Models
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Initializes a new instance of the CartItem class.
        /// </summary>
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the product of the CartItem.
        /// </summary>
        [Required]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the Product in the CartItem.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the total price of the CartItem.
        /// </summary>
        public decimal TotalPrice => Product?.Price * Quantity ?? 0M;
    }
}
