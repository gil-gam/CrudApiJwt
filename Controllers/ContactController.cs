[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetUserId();
        var contacts = await _contactService.GetAllAsync(userId);
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var userId = GetUserId();
        var contact = await _contactService.GetByIdAsync(id, userId);
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ContactCreateDto dto)
    {
        var userId = GetUserId();
        var contact = await _contactService.CreateAsync(dto, userId);
        return Ok(contact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ContactCreateDto dto)
    {
        var userId = GetUserId();
        var contact = await _contactService.UpdateAsync(id, dto, userId);
        return Ok(contact);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = GetUserId();
        var success = await _contactService.DeleteAsync(id, userId);
        return success ? NoContent() : NotFound();
    }
}
