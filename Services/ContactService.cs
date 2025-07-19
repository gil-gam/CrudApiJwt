using CrudApiJwt.Data;
using CrudApiJwt.DTOs;
using CrudApiJwt.Models;
using CrudApiJwt.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApiJwt.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllAsync(int userId)
        {
            return await _context.Contacts.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id, int userId)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            return contact ?? throw new Exception("Contato não encontrado");
        }

        public async Task<Contact> CreateAsync(ContactDTO dto, int userId)
        {
            var contact = new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                UserId = userId
            };
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateAsync(int id, ContactDTO dto, int userId)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (contact == null) throw new Exception("Contato não encontrado");

            contact.Name = dto.Name;
            contact.Email = dto.Email;
            contact.Phone = dto.Phone;

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (contact == null) return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
