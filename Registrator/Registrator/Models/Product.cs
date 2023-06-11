using System.ComponentModel.DataAnnotations;

namespace Registrator.Models
{
    /// <summary>
    /// Represents a Product in the system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier of the Product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the Product.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the Product.
        /// </summary>
        public string Description { get; set; }

        private decimal price;

        /// <summary>
        /// Gets or sets the price of the Product.
        /// Ensures that the price is never set to a negative value.
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value < 0 ? 0 : value; }
        }
    }
}
