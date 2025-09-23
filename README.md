# Instructor Service

A REST API service for managing instructor information. Built with .NET 9 and Entity Framework Core using Clean Architecture principles.

## Features

- Create, read, update, and delete instructor records
- Input validation for all operations
- SQLite database with automatic migrations
- Swagger documentation for development
- CORS support for frontend integration

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQLite (included with .NET)

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the application:

```bash
dotnet run --project Presentation
```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`)

### Development

For development with Swagger UI, the application will automatically open the API documentation at `/swagger`.

## API Endpoints

- `GET /api/instructor` - Get all instructors
- `GET /api/instructor/{id}` - Get a specific instructor
- `POST /api/instructor` - Create a new instructor
- `PUT /api/instructor/{id}` - Update an existing instructor
- `DELETE /api/instructor/{id}` - Delete an instructor

## Project Structure

The solution follows Clean Architecture with four main projects:

- **Domain** - Core entities and business logic
- **Application** - Use cases, DTOs, and service interfaces
- **Persistence** - Data access layer with Entity Framework
- **Presentation** - Web API controllers and configuration

## Database

The application uses SQLite for data storage. The database file (`instructor.db`) is created automatically in the Presentation project directory when you first run the application.

## Testing

Use the Swagger UI in development mode or any HTTP client to test the API endpoints.
