namespace ShopSphere.Models
{
    public class UpdateOrderDto
    {
        public required string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}