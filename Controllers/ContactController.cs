using CrudApiJwt.Data;
using CrudApiJwt.DTOs;
using CrudApiJwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CrudApiJwt.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var contacts = await _context.Contacts
                .Where(c => c.UserId == userId)
                .Select(c => new ContactDTO { Name = c.Name, Phone = c.Phone })
                .ToListAsync();

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDTO model)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var contact = new Contact
            {
                Name = model.Name,
                Phone = model.Phone,
                UserId = userId
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Contato criado." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Contato excluído." });
        }
    }

}
