using CrudApiJwt.Data;
using CrudApiJwt.DTOs;
using CrudApiJwt.Models;
using CrudApiJwt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApiJwt.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginDTO model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
                return BadRequest("E-mail já registrado.");

            var user = new User
            {
                Email = model.Email,
                Name = model.Email.Split('@')[0],
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuário registrado com sucesso." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return Unauthorized("Credenciais inválidas.");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }

}
