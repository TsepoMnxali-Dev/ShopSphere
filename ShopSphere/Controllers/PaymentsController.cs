using Microsoft.AspNetCore.Mvc;
using ShopSphere.Data;
using ShopSphere.Models.DTOs;
using ShopSphere.Models.Entities;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Reading all Payments from the Payments table.
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var allPayments = dbContext.Payments.ToList();
            return Ok(allPayments);
        }

        // Reading individual Payment by Id.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPaymentById(Guid id)
        {
            var payment = dbContext.Payments.Find(id);

            if (payment is null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // Adding a new Payment to the Payments table.
        [HttpPost]
        public IActionResult AddPayment(AddPaymentDto addPaymentDto)
        {
            var paymentEntity = new Payment()
            {
                OrderId = addPaymentDto.OrderId,
                Amount = addPaymentDto.Amount,
                Status = addPaymentDto.Status,
                PaymentDate = addPaymentDto.PaymentDate
            };

            dbContext.Payments.Add(paymentEntity);
            dbContext.SaveChanges();

            return Ok(paymentEntity);
        }

        // Updating a Payment status from the Payments table.
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePayment(Guid id, UpdatePaymentDto updatePaymentDto)
        {
            var payment = dbContext.Payments.Find(id);

            if (payment is null)
            {
                return NotFound();
            }

            payment.Status = updatePaymentDto.Status;

            dbContext.SaveChanges();
            return Ok(payment);
        }

        // Deleting a Payment from the Payments table.
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeletePayment(Guid id)
        {
            var payment = dbContext.Payments.Find(id);

            if (payment is null)
            {
                return NotFound();
            }

            dbContext.Payments.Remove(payment);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}