using System.ComponentModel.DataAnnotations;

namespace ShopSphere.Models.Entities
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public required string Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}