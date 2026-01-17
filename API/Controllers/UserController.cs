using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService ser;
        public UserController(UserService ser)
        {
            this.ser = ser;
        }
        [HttpPost("Create")]
        public IActionResult Create(UserDTO user)
        {
            var r = ser.Create(user);
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
        public IActionResult Update(UserDTO user)
        {
            var r = ser.Update(user);

            if (!r)
                return BadRequest("Update failed");

            return Ok("User updated successfully");
        }
        [HttpPatch("Update{id}")]
        public IActionResult Update(int id, UserDTO User)
        {
            var r = ser.Update(User);

            if (!r)
                return BadRequest("ID mismatch");

            return Ok("User updated successfully");
        }
    }
}
