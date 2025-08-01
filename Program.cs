using Microsoft.EntityFrameworkCore;
using AddressBookBackend.Data;

using AddressBookBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with SQLite
builder.Services.AddDbContext<AddressBookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors(policy => 
    policy.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .WithExposedHeaders("Content-Disposition")); // Crucial for file downloads

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// app.UseCors(policy => 
//     policy.WithOrigins("http://localhost:4200")
//           .AllowAnyMethod()
//           .AllowAnyHeader());

app.MapControllers();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AddressBookContext>();
    context.Database.EnsureCreated(); // Creates the database and seeds the data
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AddressBookContext>();
    context.Database.EnsureDeleted(); // Deletes existing DB
    context.Database.EnsureCreated(); // Creates new DB with current schema
}

app.Run();