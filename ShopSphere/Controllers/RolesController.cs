using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using ShopSphere.Models.Entities;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public RolesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Reading all Roles from the Roles table.
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var allRoles = dbContext.Roles.ToList();
            return Ok(allRoles);
        }

        // Reading individual Role by Id.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRoleById(Guid id)
        {
            var role = dbContext.Roles.Find(id);

            if (role is null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // Adding a new Role to the Roles table.
        [HttpPost]
        public IActionResult AddRole(AddRoleDto addRoleDto)
        {
            var roleEntity = new Role()
            {
               
                RoleName = addRoleDto.RoleName
            };

            dbContext.Roles.Add(roleEntity);
            dbContext.SaveChanges();

            return Ok(roleEntity);
        }

        // Updating a Role from the Roles table.
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateRole(Guid id, UpdateRoleDto updateRoleDto)
        {
            var role = dbContext.Roles.Find(id);

            if (role is null)
            {
                return NotFound();
            }

            role.RoleName = updateRoleDto.RoleName;

            dbContext.SaveChanges();
            return Ok(role);
        }

        // Deleting a Role from the Roles table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRole(Guid id)
        {
            var role = dbContext.Roles.Find(id);

            if (role is null)
            {
                return NotFound();
            }

            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}