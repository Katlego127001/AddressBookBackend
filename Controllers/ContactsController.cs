using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBookApi.Data;
using AddressBookApi.Models;

namespace AddressBookApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly AddressBookContext _context;

    public ContactsController(AddressBookContext context)
    {
        _context = context;
    }

    // GET: api/Contacts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    // GET: api/Contacts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContact(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        return contact;
    }

    // GET: api/Contacts/count
    [HttpGet("count")]
    public async Task<ActionResult<int>> GetContactsCount()
    {
        return await _context.Contacts.CountAsync();
    }
}