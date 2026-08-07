using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using ShopSphere.Models.Entities;
using System.ComponentModel;

namespace ShopSphere.Controllers
{// localhost: xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //Reading all the Users from the Users table.
        [HttpGet]
        public IActionResult GetAllUsers()
        {
           var allUsers = dbContext.Users.ToList();
            return Ok(allUsers);

            // other alternative shoter way to write what is written abover is 
            // return Ok(dbContext.Users.ToList());
        }

        //Reading individual users from the users table by Id
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
           var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Adding users to the Users table, also note: we are going to use DTOs for this.
        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new User()
            {

                Name = addUserDto.Name,
                Email = addUserDto.Email,
                PasswordHash = addUserDto.PasswordHash,
                RoleId = addUserDto.RoleId

            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        // Updating a user from the users tables
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUsersDto updateUsersDto)
        {
            var user = dbContext.Users.Find(id);

            if(user is null)
            {
                return NotFound();
            }
            user.Name = updateUsersDto.Name;
            user.Email = updateUsersDto.Email;
            user.PasswordHash = updateUsersDto.PasswordHash;
            user.RoleId = updateUsersDto.RoleId;

                dbContext.SaveChanges();
            return Ok(user);
                

        }

        // Deleting a user from the users table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
