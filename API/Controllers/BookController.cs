using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService ser;
        public BookController(BookService ser)
        {
            this.ser = ser;
        }
        [HttpPost("Create")]
        public IActionResult Create(BookDTO book)
        {
            var r = ser.Create(book);
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
        public IActionResult Update(BookDTO book)
        {
            var r = ser.Update(book);

            if (!r)
                return BadRequest("Update failed");

            return Ok("Book updated successfully");
        }
        [HttpPatch("Update{id}")]
        public IActionResult Update(int id, BookDTO book)
        {
            var r = ser.Update(book);

            if (!r)
                return BadRequest("ID mismatch");

            return Ok("Book updated successfully");
        }


        [HttpGet("LowStock")]
        public IActionResult LowStock(int low = 5)
        {
            var data = ser.GetLowStock(low);
            return Ok(data);
        }

        [HttpGet("search")]
public IActionResult AdvancedSearch(
    string title,
    string author,
    string genre,
    decimal? minPrice,
    decimal? maxPrice)
{
    var data = ser.AdvancedSearch(title, author, genre, minPrice, maxPrice);
    return Ok(data);
}
    }
}
