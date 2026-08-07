namespace ShopSphere.Models
{
    public class UpdateUsersDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public Guid RoleId { get; set; }  // changed from int to Guid
    }
}