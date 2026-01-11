# Register System 🛡️

A professional-grade User Management & Authentication system built with **ASP.NET Core 9**, implementing **Clean Architecture** and **CQRS**. This project serves as a reference implementation for secure identity management using **Identity Core** and **JWT**.

## Features

- **Clean Architecture**: Strict separation of concerns between API, Application, Domain, and Infrastructure layers.
- **Identity Core**: Robust user management with customized password security policies.
- **JWT Authentication**: Secure stateless authentication using Bearer tokens with claim-based identity.
- **Advanced Exception Handling**: Centralized error management using the modern .NET 9 `IExceptionHandler` (RFC 7807 compliant).
- **MediatR (CQRS)**: Decoupled business logic using commands and queries.
- **User Context Bridge**: Abstracted user identity access via `IUserContext` to keep the Application layer pure.
- **Environment Safety**: Secure configuration management via `.env` files.

## Architectural Layers

- **Domain**: Contains the `ApplicationUser` entity and core business rules.
- **Application**: Features MediatR handlers for Register, Login, and Profile retrieval.
- **Infrastructure**: Handles EF Core persistence (MariaDB), JWT generation logic, and Identity services.
- **API**: REST Controllers, Middleware configuration, and Dependency Injection setup.

## Tech Stack

- **Framework**: ASP.NET Core 9.0
- **Database**: MariaDB / MySQL (via Entity Framework Core)
- **Patterns**: CQRS, Mediator, Dependency Injection, Global Error Handling.
- **Libraries**: MediatR, Microsoft.AspNetCore.Identity, DotNetEnv.

## Setup

1. **Clone the repository**:

```bash
git clone https://github.com/marvin-dev76/register-system.git
```

2. **Environment Configuration: Create a .env file in the root directory (refer to .env.example if available) and provide your**:
- `DB_CONNECTION_STRING`
- `JWT_SECRET`, `JWT_ISSUER`, and `JWT_AUDIENCE`

3. **Apply Migrations**:
```bash
dotnet ef database update
```
4. **Run the Application**:
```bash
dotnet run --project ./RegisterSystem.API
```

## Security Note

This project uses `.env` files for local development. Never commit the `.env` file to version control. A .gitignore is included to prevent sensitive data leaks.