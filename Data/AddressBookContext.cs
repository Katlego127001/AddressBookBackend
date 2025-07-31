using Microsoft.EntityFrameworkCore;
using AddressBookApi.Models;

namespace AddressBookApi.Data;

public class AddressBookContext : DbContext
{
    public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed initial data
        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                FirstName = "John",
                Surname = "Doe",
                Email = "john@example.com",
                Phone = "012 345 6789",
                Website = "www.johndoe.co.za",
                Bio = "Some funny text about John Doe. It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout."
            },
            new Contact
            {
                Id = 2,
                FirstName = "Jane",
                Surname = "Smith",
                Email = "jane@example.com",
                Phone = "098 765 4321",
                Website = "www.janesmith.co.za",
                Bio = "Some information about Jane Smith. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters."
            },
            new Contact
            {
                Id = 3,
                FirstName = "Bob",
                Surname = "Johnson",
                Email = "bob@example.com",
                Phone = "011 222 3333",
                Website = "www.bobjohnson.co.za",
                Bio = "Details about Bob Johnson. There are many variations of passages of Lorem Ipsum available."
            }
        );
    }
}