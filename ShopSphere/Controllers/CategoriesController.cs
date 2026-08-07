using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using ShopSphere.Models.Entities;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Reading all Categories from the Categories table.
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var allCategories = dbContext.Categories.ToList();
            return Ok(allCategories);
        }

        // Reading individual Category by Id.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = dbContext.Categories.Find(id);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // Adding a new Category to the Categories table.
        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            var categoryEntity = new Category()
            {
                Name = addCategoryDto.Name
            };

            dbContext.Categories.Add(categoryEntity);
            dbContext.SaveChanges();

            return Ok(categoryEntity);
        }

        // Updating a Category from the Categories table.
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var category = dbContext.Categories.Find(id);

            if (category is null)
            {
                return NotFound();
            }

            category.Name = updateCategoryDto.Name;

            dbContext.SaveChanges();
            return Ok(category);
        }

        // Deleting a Category from the Categories table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = dbContext.Categories.Find(id);

            if (category is null)
            {
                return NotFound();
            }

            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}