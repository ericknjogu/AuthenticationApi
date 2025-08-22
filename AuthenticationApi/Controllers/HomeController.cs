using AuthenticationApi.Data;
using AuthenticationApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AtchrmlocalContext _atchrm;

        public HomeController(AtchrmlocalContext atchrm)
        {
            _atchrm = atchrm;
        }


        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var users = await _atchrm.EmpDetails
                    .Select(u => new EmpDetail { EmpId = u.EmpId, EmpName = u.EmpName })
                    
                    .ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
