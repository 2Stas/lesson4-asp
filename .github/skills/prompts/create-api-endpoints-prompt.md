# SKILL CreateAPIEndpoint

## Purpose

```
This Skill creates complete API endpoints for ASP.NET Core Web API projects.

It generates RESTful API endpoints with proper routing, HTTP methods, parameter binding, model validation, dependency injection, service integration, error handling, response types, and documentation.

The Skill must follow the existing architecture and coding patterns of the project instead of introducing unnecessary new patterns or dependencies.
```

## When to use

```
Use this Skill when:

- Creating a new API endpoint.
- Adding GET, POST, PUT, PATCH, or DELETE operations.
- Creating CRUD endpoints.
- Creating custom API actions or queries.
- Adding route parameters or query parameters.
- Defining request or response models.
- Adding validation to API requests.
- Connecting an endpoint to an existing service.
- Connecting an endpoint to Entity Framework Core.
- Returning appropriate HTTP responses.
- Adding a new API controller.
```

## Context

```
The Skill operates within an ASP.NET Core Web API project.

Relevant project areas include:

Controllers/
Models/
DTOs/
Services/
Interfaces/
Data/
Program.cs
appsettings.json

The Skill should inspect existing:

- Controllers
- Services
- Service interfaces
- Models
- DTOs
- DbContext
- Entity Framework Core configuration
- Dependency Injection configuration
- Routing conventions
- Error handling patterns

Existing project code is the primary source for determining how the new endpoint should be implemented.
```

## Inputs

```
The input provided by the user should contain:

- **Feature / Action Goal**: What the endpoint should do.

- **HTTP Method**: GET, POST, PUT, PATCH, or DELETE.

- **Route URL**: For example:
  `/api/orders`
  `/api/orders/{id}`
  `/api/orders/{id}/status`

- **Parameters**:
    - Route parameters
    - Query parameters
    - Request body
    - Headers, if required

- **Request Data**:
  Properties that the endpoint receives.

- **Validation Requirements**:
  Required fields, ranges, string lengths, formats, etc.

- **Expected Response**:
  Data that should be returned and the appropriate HTTP status code.

- **Existing Service or Database**:
  Which service, interface, DbContext, or entity should be used.

- **Authentication Requirements**, if applicable.
```

## Workflow

### 1. Analyze Endpoint Requirements

```
Determine:

- What the endpoint should do.
- HTTP method.
- Route.
- Parameters.
- Request body.
- Expected response.
- Possible error cases.
- Required status codes.
```

### 2. Inspect Existing Project Patterns

```
Check existing controllers and services.

Determine:

- Controller naming conventions.
- Route conventions.
- Service usage.
- DTO usage.
- Validation patterns.
- Error handling.
- Response format.
- Entity Framework Core usage.

Reuse existing patterns whenever possible.
```

### 3. Define Request and Response Models

```
Create DTOs or models when required.

Add appropriate validation attributes:

- `[Required]`
- `[StringLength]`
- `[MinLength]`
- `[MaxLength]`
- `[Range]`
- `[EmailAddress]`
- `[Compare]`
- `[RegularExpression]`

Do not create additional DTOs if the project already has a suitable existing model and using it is consistent with the project architecture.
```

### 4. Define Controller

```
Create or modify the appropriate controller.

Apply:

- `[ApiController]` when used by the project.
- `[Route("api/[controller]")]` or the project's existing route convention.

Inject required services through the constructor.
```

### 5. Implement Endpoint

```
Apply the appropriate HTTP attribute:

`[HttpGet]`

`[HttpGet("{id}")]`

`[HttpPost]`

`[HttpPut("{id}")]`

`[HttpPatch("{id}")]`

`[HttpDelete("{id}")]`

Use appropriate parameter binding:

`[FromRoute]`

`[FromQuery]`

`[FromBody]`

`[FromHeader]`
```

### 6. Implement Validation

```
Validate incoming data according to the project's existing validation approach.

When manual validation is required, check:

`ModelState.IsValid`

Return an appropriate `400 Bad Request` response when validation fails.
```

### 7. Implement Business Logic

```
Use the existing service layer when the project has one.

Controller:

Request
    ↓
Service
    ↓
Database
    ↓
Response

Do not place large amounts of business logic inside the controller when the project already separates business logic into services.
```

### 8. Implement Database Operations

```
When Entity Framework Core is used:

- Use the existing DbContext.
- Use existing DbSet properties.
- Follow existing entity relationships.
- Use existing query patterns.
- Call `SaveChanges()` or `SaveChangesAsync()` when required.
```

### 9. Handle Errors

```
Handle expected errors such as:

- Invalid request → `400 Bad Request`
- Unauthorized request → `401 Unauthorized`
- Forbidden request → `403 Forbidden`
- Entity not found → `404 Not Found`
- Server error → `500 Internal Server Error`

Follow the project's existing error-handling pattern.
```

### 10. Add Documentation

```
When the project uses endpoint documentation, add:

- XML com
```
