using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService ser;
        public OrderController(OrderService ser)
        {
            this.ser = ser;
        }
        [HttpPost("Create")]
        public IActionResult Create(OrderDTO order)
        {
            var r = ser.Create(order);
            return Ok(r);
        }

        [HttpGet("All")]
        public IActionResult All()
        {
            var data = ser.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var data = ser.Get(id);
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var r = ser.Delete(id);
            return Ok(r);
        }
        [HttpPut("Update")]
        public IActionResult Update(OrderDTO order)
        {
            var r = ser.Update(order);

            if (!r)
                return BadRequest("Update failed");

            return Ok(" Order updated successfully");
        }
        [HttpPatch("Update{id}")]
        public IActionResult Update(int id, OrderDTO order)
        {
            var r = ser.Update(order);

            if (!r)
                return BadRequest("ID mismatch");

            return Ok(" Order updated successfully");
        }


        [HttpGet("orders-count")]
        public IActionResult GetOrdersCount()
        {
            var data = ser.GetOrdersCount();
            return Ok(data);
        }
        [HttpGet("daily")]
        public IActionResult DailySales()
        {
            return Ok(ser.GetDailySales());
        }

        [HttpGet("bill/{id}")]
        public IActionResult GetBill(int id)
        {
            var bill = ser.GenerateBill(id);

            if (bill == null)
                return NotFound("Order not found");

            return Ok(bill);
        }
    }
}
