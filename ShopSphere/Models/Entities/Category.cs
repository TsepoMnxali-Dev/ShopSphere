using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Models.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public required string Name { get; set; }
    }
}