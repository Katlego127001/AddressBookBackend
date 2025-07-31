using Microsoft.EntityFrameworkCore;

namespace AddressBookBackend.Data;

using AddressBookBackend.Models;  


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
                FirstName = "Thabo",
                Surname = "Dlamini",
                Email = "thabo@example.com",
                Phone = "067 123 4567",
                Website = "www.thabodlamini.co.za",
                Bio = "Thabo is a talented civil engineer from Johannesburg with a passion for sustainable urban development. He has led several major infrastructure projects across the Gauteng province and is an expert in green building practices. Outside of work, he is a dedicated rugby fan and a mentor to young engineering students.",
                ImageUrl = "https://randomuser.me/api/portraits/men/10.jpg"
            },
            new Contact
            {
                Id = 2,
                FirstName = "Anika",
                Surname = "van der Merwe",
                Email = "anika@example.com",
                Phone = "082 987 6543",
                Website = "www.anikavdm.co.za",
                Bio = "Anika is a highly creative graphic designer and brand consultant from Cape Town. She is known for her vibrant and culturally rich designs, specializing in digital and print media for small businesses. She also runs a popular blog about South African art and culture.",
                ImageUrl = "https://randomuser.me/api/portraits/women/10.jpg"
            },
            new Contact
            {
                Id = 3,
                FirstName = "Sizwe",
                Surname = "Nkosi",
                Email = "sizwe@example.com",
                Phone = "071 555 4444",
                Website = "www.sizwenkosi.co.za",
                Bio = "Sizwe is a seasoned project manager with over 15 years of experience in the telecommunications industry. Originally from Durban, he is an expert in leading large-scale projects from conception to completion. He is also a keen amateur sailor and enjoys spending his weekends on the water.",
                ImageUrl = "https://randomuser.me/api/portraits/men/11.jpg"
            },
            new Contact
            {
                Id = 4,
                FirstName = "Liezl",
                Surname = "Pretorius",
                Email = "liezl@example.com",
                Phone = "060 111 2222",
                Website = "www.liezlpretorius.co.za",
                Bio = "Liezl is a dedicated community development worker from the Eastern Cape. With a background in social work, she is passionate about empowering women and children through education and skills training. Her work has earned her several local awards for social impact.",
                ImageUrl = "https://randomuser.me/api/portraits/women/11.jpg"
            },
            new Contact
            {
                Id = 5,
                FirstName = "Bongani",
                Surname = "Zuma",
                Email = "bongani@example.com",
                Phone = "079 333 8888",
                Website = "www.bonganizuma.co.za",
                Bio = "Bongani is a full-stack developer with a focus on fintech solutions. Based in Pretoria, he is an expert in building secure and efficient financial platforms. He is a fan of open-source projects and often contributes to the tech community in his free time.",
                ImageUrl = "https://randomuser.me/api/portraits/men/12.jpg"
            },
            new Contact
            {
                Id = 6,
                FirstName = "Caitlyn",
                Surname = "Adams",
                Email = "caitlyn@example.com",
                Phone = "083 444 9999",
                Website = "www.caitlynadams.co.za",
                Bio = "Caitlyn is an award-winning chef and restaurant owner from Soweto. She is celebrated for her modern twist on traditional South African cuisine. Caitlyn is passionate about using locally-sourced ingredients and runs a popular cooking class on weekends.",
                ImageUrl = "https://randomuser.me/api/portraits/women/12.jpg"
            }
        );
    }
}