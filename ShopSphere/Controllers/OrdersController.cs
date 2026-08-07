using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models;
using ShopSphere.Models.Entities;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public OrdersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Reading all Orders from the Orders table.
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var allOrders = dbContext.Orders.ToList();
            return Ok(allOrders);
        }

        // Reading individual Order by Id.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = dbContext.Orders.Find(id);

            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // Adding a new Order to the Orders table.
        [HttpPost]
        public IActionResult AddOrder(AddOrderDto addOrderDto)
        {
            var orderEntity = new Order()
            {
                UserId = addOrderDto.UserId,
                OrderDate = addOrderDto.OrderDate,
                Status = addOrderDto.Status,
                TotalAmount = addOrderDto.TotalAmount
            };

            dbContext.Orders.Add(orderEntity);
            dbContext.SaveChanges();

            return Ok(orderEntity);
        }

        // Updating an Order from the Orders table (status changes).
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateOrder(Guid id, UpdateOrderDto updateOrderDto)
        {
            var order = dbContext.Orders.Find(id);

            if (order is null)
            {
                return NotFound();
            }

            order.Status = updateOrderDto.Status;
            order.TotalAmount = updateOrderDto.TotalAmount;

            dbContext.SaveChanges();
            return Ok(order);
        }

        // Deleting an Order from the Orders table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = dbContext.Orders.Find(id);

            if (order is null)
            {
                return NotFound();
            }

            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}