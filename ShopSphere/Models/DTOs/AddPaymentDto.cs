namespace ShopSphere.Models.DTOs
{
    public class AddPaymentDto
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public required string Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}