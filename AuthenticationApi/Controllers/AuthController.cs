using AuthenticationApi.Data;
using AuthenticationApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
      private readonly AppDbContext _db;

        public AuthController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login ([FromBody] User login)
        {
            if (login == null || string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid user data.");
            }
            var existingUser = await _db.Users.SingleOrDefaultAsync(u => u.UserName == login.UserName && u.Password == login.Password);

            if (existingUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(new { message="Login successful.",UserId=existingUser.Id, Username=existingUser.UserName });
        }
    }
}
