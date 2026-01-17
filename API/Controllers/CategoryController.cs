using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService ser;
        public CategoryController(CategoryService ser)
        {
            this.ser =ser;
        }
        [HttpPost("Create")]
        public IActionResult Create(CategoryDTO c)
        {
            var r = ser.Create(c);
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
        public IActionResult Update(CategoryDTO c)
        {
            var r = ser.Update(c);

            if (!r)
                return BadRequest("Update failed");

            return Ok("Category updated successfully");
        }
        [HttpPatch("Update{id}")]
        public IActionResult Update(int id ,CategoryDTO c)
        {
            var r = ser.Update(c);

            if (!r)
                return BadRequest("ID mismatch");

            return Ok("Category updated successfully");
        }

    }
}
