# Address Book Application

A full-stack address book application with profile browsing and CV download functionality.

## Features

- Browse contact profiles with navigation controls
- View contact details (name, email, phone, bio)
- Download professional CVs in PDF format
- Responsive design with Angular Material
- RESTful API backend with .NET Core
- SQLite database with seeded sample data

## Technologies

**Backend:**
- .NET Core 9.0
- Entity Framework Core
- SQLite
- iText7 (PDF generation)
- Swagger (API documentation)

**Frontend:**
- Angular 17
- Angular Material
- TypeScript
- RxJS

## Setup Instructions

### Backend Setup

1. **Prerequisites**:
   - [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
   - [SQLite](https://sqlite.org/download.html)

2. **Install dependencies**:
   ```bash
   cd AddressBookBackend
   dotnet restore
   dotnet add package itext7 --version 7.2.5

3. Database setup:
-The application will automatically create and seed the database on first run

4. Run the backend:
- dotnet run

API will be available at https://localhost:5008

Swagger UI at http://localhost:5008/swagger/index.html

API Endpoints
Endpoint	Method	Description
/api/contacts	GET	Get all contacts
/api/contacts/{id}	GET	Get specific contact
/api/contacts/count	GET	Get total contact count
/api/contacts/{id}/cv	GET	Download contact's CV (PDF)
