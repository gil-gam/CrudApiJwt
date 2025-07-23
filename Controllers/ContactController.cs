using CrudApiJwt.DTOs;
using CrudApiJwt.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiJwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Retorna todos os contatos do usuário autenticado.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var contacts = await _contactService.GetAllAsync(userId);
            return Ok(contacts);
        }

        /// <summary>
        /// Retorna um contato específico pelo ID.
        /// </summary>
        /// <param name="id">ID do contato</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = GetUserId();
            var contact = await _contactService.GetByIdAsync(id, userId);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        /// <summary>
        /// Cria um novo contato.
        /// </summary>
        /// <param name="dto">DTO contendo os dados do contato</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] ContactDTO dto)
        {
            var userId = GetUserId();
            var contact = await _contactService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        /// <summary>
        /// Atualiza um contato existente.
        /// </summary>
        /// <param name="id">ID do contato</param>
        /// <param name="dto">DTO com os dados atualizados</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDTO dto)
        {
            var userId = GetUserId();
            var updated = await _contactService.UpdateAsync(id, dto, userId);
            if (updated == null) return NotFound();

            return Ok(new { message = "Contato atualizado com sucesso." });
        }

        /// <summary>
        /// Exclui um contato.
        /// </summary>
        /// <param name="id">ID do contato</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            var deleted = await _contactService.DeleteAsync(id, userId);
            if (!deleted) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Recupera o ID do usuário autenticado via token JWT.
        /// </summary>
        private int GetUserId()
        {
            return int.Parse(User.FindFirst("id")?.Value ?? throw new Exception("Usuário não autenticado"));
        }
    }
}
