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

        try 
        {
            // Create a temporary memory stream for PDF generation
            var tempStream = new MemoryStream();
            
            // Generate PDF to temporary stream
            using (var writer = new PdfWriter(tempStream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                // PDF Content
                document.Add(new Paragraph("CURRICULUM VITAE")
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
                document.Add(new Paragraph("PROFESSIONAL SUMMARY"));
                document.Add(new Paragraph(contact.Bio));
            }

            // Create a new stream from the generated PDF bytes
            var pdfBytes = tempStream.ToArray();
            var resultStream = new MemoryStream(pdfBytes);
            
            // Return the file - resultStream will be disposed by FileStreamResult
            return File(resultStream, "application/pdf", $"{contact.FirstName}_{contact.Surname}_CV.pdf");
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"CV Generation Error: {ex}");

            return StatusCode(500, $"CV generation failed: {ex.Message}");
        }
    }
}