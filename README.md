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

### Using Swagger UI

When running in development mode, navigate to `/swagger` to access the interactive API documentation. You can test creating an instructor directly in the browser:

1. Expand the `POST /api/instructor` endpoint
2. Click "Try it out"
3. Use this example JSON in the request body:

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "phone": "+1-555-123-4567",
  "location": "New York",
  "profilePicture": "https://example.com/profile.jpg",
  "isActive": true
}
```

### Using curl

To create an instructor using curl from the command line:

```bash
curl -X POST "https://localhost:5001/api/instructor" \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Jane",
    "lastName": "Smith",
    "email": "jane.smith@example.com",
    "phone": "+1-555-987-6543",
    "location": "Los Angeles",
    "profilePicture": "https://example.com/jane-profile.jpg",
    "isActive": true
  }'
```

**Note:** The `profilePicture` field is optional. All other fields are required and have validation rules:

- First/Last name: 2-50 characters
- Email: Must be a valid email format
- Phone: Must be a valid phone number format
- Location: Maximum 100 characters
