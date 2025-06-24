using CrudApiJwt.Data;
using CrudApiJwt.Models;
using CrudApiJwt.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApiJwt.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? throw new Exception("Usuário não encontrado");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
