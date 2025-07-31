using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AddressBookBackend.Models;  
using AddressBookBackend.Data;  

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace AddressBookBackend.Controllers;

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

    //Get CV
    [HttpGet("{id}/cv")]
    public IActionResult DownloadCv(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact == null) return NotFound();
        
        // Create a simple PDF in memory
        var stream = new MemoryStream();
        var writer = new PdfWriter(stream);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);
        
        // Add CV content
        document.Add(new Paragraph($"Curriculum Vitae")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(20));
        
        document.Add(new Paragraph($"{contact.FirstName} {contact.Surname}")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(16));
        
        document.Add(new Paragraph(" "));
        document.Add(new Paragraph($"Email: {contact.Email}"));
        document.Add(new Paragraph($"Phone: {contact.Phone}"));
        document.Add(new Paragraph($"Website: {contact.Website}"));
        document.Add(new Paragraph(" "));
        document.Add(new Paragraph("Professional Summary"));
        document.Add(new Paragraph(contact.Bio));
        
        document.Close();
        
        return File(stream.ToArray(), "application/pdf", $"{contact.FirstName}_{contact.Surname}_CV.pdf");
    }
}