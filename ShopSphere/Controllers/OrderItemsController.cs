using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using ShopSphere.Models.Entities;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public OrderItemsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Reading all Order Items by OrderId.
        [HttpGet]
        [Route("order/{orderId:guid}")]
        public IActionResult GetItemsByOrderId(Guid orderId)
        {
            var orderItems = dbContext.OrderItems
                .Where(item => item.OrderId == orderId)
                .ToList();

            if (orderItems is null || orderItems.Count == 0)
            {
                return NotFound();
            }

            return Ok(orderItems);
        }

        // Reading individual Order Item by Id.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetOrderItemById(Guid id)
        {
            var orderItem = dbContext.OrderItems.Find(id);

            if (orderItem is null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        // Adding a new Order Item to the OrderItems table.
        [HttpPost]
        public IActionResult AddOrderItem(AddOrderItemDto addOrderItemDto)
        {
            var orderItemEntity = new OrderItem()
            {
                OrderId = addOrderItemDto.OrderId,
                ProductId = addOrderItemDto.ProductId,
                Quantity = addOrderItemDto.Quantity,
                Price = addOrderItemDto.Price
            };

            dbContext.OrderItems.Add(orderItemEntity);
            dbContext.SaveChanges();

            return Ok(orderItemEntity);
        }

        // Updating an Order Item (quantity and price).
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateOrderItem(Guid id, UpdateOrderItemDto updateOrderItemDto)
        {
            var orderItem = dbContext.OrderItems.Find(id);

            if (orderItem is null)
            {
                return NotFound();
            }

            orderItem.Quantity = updateOrderItemDto.Quantity;
            orderItem.Price = updateOrderItemDto.Price;

            dbContext.SaveChanges();
            return Ok(orderItem);
        }

        // Removing an Order Item from the OrderItems table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteOrderItem(Guid id)
        {
            var orderItem = dbContext.OrderItems.Find(id);

            if (orderItem is null)
            {
                return NotFound();
            }

            dbContext.OrderItems.Remove(orderItem);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}