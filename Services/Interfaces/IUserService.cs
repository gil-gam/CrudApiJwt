using CrudApiJwt.Models;

namespace CrudApiJwt.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
    }
}
