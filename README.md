# ShelfSpeak - A Book Library Management Application

ShelfSpeak is a C# .NET application designed for managing and organizing your personal book library. It allows users to search for books using the Open Library API, add books to their library, and view their collection.

## Features

- **Search Books:** Utilize the Open Library API to search for books based on keywords.
- **Add to Library:** Add interesting books to your personal library with just a click.
- **User Authentication:** Securely manage your library with user authentication using ASP.NET Identity.
- **User Profile:** Personalize your experience with a profile picture and bio.

## Prerequisites

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [PostgreSQL](https://www.postgresql.org/) (or any other database supported by Entity Framework)

## Getting Started

1. **Clone the repository:**

2. **Set up the database:**
   
    - Ensure that PostgreSQL (or your preferred database) is installed.
    - Create a database and update the connection string in `appsettings.json` with your database information.

3. **Configure Open Library API:**

    - Read the documentation from [Open Library](https://openlibrary.org/developers/api) and update the configuration in `appsettings.json`.

4. **Build and run the application:**

5. **Access the application in your web browser:**

    Running the application should open it in your browser

## Configuration

- The application uses [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) for database operations. Ensure that the connection string in `appsettings.json` is correctly configured.

- User authentication is configured with ASP.NET Identity. Adjust authentication settings in `Program.cs` if needed.

## Contributions

Contributions are welcome! If you have any ideas for improvements or find issues, feel free to open an [issue](https://github.com/abukhmirov/ShelfSpeak/issues) or submit a [pull request](https://github.com/abukhmirov/ShelfSpeak/pulls).
