namespace ShopSphere.Models
{
    public class AddOrderDto
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public required string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}