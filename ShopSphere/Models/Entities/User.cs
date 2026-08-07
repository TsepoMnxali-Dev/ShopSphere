using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopSphere.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public Guid RoleId { get; set; } 
    }
}
