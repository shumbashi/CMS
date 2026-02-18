# Contract Management System (CMS)

A headless Contract Management System built with .NET 10.0 and MySQL. This project provides a robust API for managing users, documents, contract parties, templates, and more.

## Architecture

The project follows a **Clean Architecture** pattern:

- **Api**: The entry point, containing controllers and minimal API endpoints.
- **Application**: Contains DTOs, interfaces, and business logic (using MediatR and FluentValidation).
- **Domain**: Contains core entities and common abstractions.
- **Infrastructure**: Handles data persistence (Entity Framework Core), repositories, and migrations.

## Tech Stack

- **Framework**: .NET 10.0
- **Database**: MySQL 8.0
- **ORM**: Entity Framework Core with Pomelo provider
- **Communication**: MediatR (CQRS pattern)
- **Validation**: FluentValidation
- **Containerization**: Docker & Docker Compose
- **Documentation**: Swagger/OpenAPI

## Getting Started

### Prerequisites

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Running with Docker

The easiest way to run the whole stack is using Docker Compose. This will start both the API and the MySQL database.

1.  Clone the repository.
2.  In the root directory, run:
    ```bash
    docker compose up --build
    ```

The system includes **automatic database migrations**. On startup, the API will wait for the database to be healthy and then apply any pending migrations.

### API Documentation

Once the containers are running, you can access the Swagger UI at:

`http://localhost:8080/swagger`

## Development

If you want to run the project locally without Docker:

1.  Ensure you have a MySQL server running.
2.  Update the connection string in `Api/appsettings.json`.
3.  Run the API project:
    ```bash
    cd Api
    dotnet run
    ```

## Project Structure

```text
├── Api/              # Web API Layer
├── Application/      # Business Logic Layer
├── Domain/           # Core Domain Entities
├── Infrastructure/   # Data Access & External Services
├── CMS/              # Placeholder/Template project
├── Dockerfile        # Multi-stage Docker build file
└── docker-compose.yml # Service orchestration
```
