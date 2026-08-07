using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Models.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public required string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}