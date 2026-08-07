using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Models.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public required string ImageUrl { get; set; }
    }
}