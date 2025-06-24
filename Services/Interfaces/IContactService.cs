using CrudApiJwt.DTOs;
using CrudApiJwt.Models;

namespace CrudApiJwt.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync(int userId);
        Task<Contact> GetByIdAsync(int id, int userId);
        Task<Contact> CreateAsync(ContactCreateDto dto, int userId);
        Task<Contact> UpdateAsync(int id, ContactCreateDto dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }
}
