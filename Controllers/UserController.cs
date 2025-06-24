using CrudApiJwt.Data;
using CrudApiJwt.DTOs;
using CrudApiJwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CrudApiJwt.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound();

            return Ok(new UserDTO { Name = user.Name, Email = user.Email });
        }
    }

}
