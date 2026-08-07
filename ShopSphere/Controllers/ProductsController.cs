using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using ShopSphere.Models.Entities;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Reading all Products from the Products table.
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var allProducts = dbContext.Products.ToList();
            return Ok(allProducts);
        }

        // Reading individual Product by Id.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // Adding a new Product to the Products table.
        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            var productEntity = new Product()
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                Price = addProductDto.Price,
                StockQuantity = addProductDto.StockQuantity,
                CategoryId = addProductDto.CategoryId,
                ImageUrl = addProductDto.ImageUrl
            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);
        }

        // Updating a Product from the Products table.
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            var product = dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.StockQuantity = updateProductDto.StockQuantity;
            product.CategoryId = updateProductDto.CategoryId;
            product.ImageUrl = updateProductDto.ImageUrl;

            dbContext.SaveChanges();
            return Ok(product);
        }

        // Deleting a Product from the Products table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}