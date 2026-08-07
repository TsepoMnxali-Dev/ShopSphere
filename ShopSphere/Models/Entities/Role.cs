namespace ShopSphere.Models.Entities
{
    public class Role
    {
        public Guid id { get; set; }
        public required string RoleName { get; set; } // (Admin / Ccustomer)

    }
}
