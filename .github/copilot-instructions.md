# Project Instructions

## Project
    This is an ASP.NET Core Web API school project that manages order creation, searching for orders, and displaying order data.

## Architecture
    - OrderController.cs in Controllers
    - OrderModel.cs in Models
    - Entity Framework Core / DbContext for data access

## Rules

# Code Style & Standards
    Follow standard C# naming conventions (PascalCase for methods/classes, camelCase for variables)

    Keep controllers clean and readable

    Use async/await for database operations

    Return proper HTTP status codes (200 OK, 201 Created, 400 BadRequest, 404 NotFound) using ActionResult<T>

# Before Changing Code
    Review existing code in OrderController.cs and related models to understand the current implementation

    Ensure that new changes will not break existing API endpoints

    Confirm that code duplication is avoided

# After
    Verify that the application builds cleanly and runs without errors

    Clean up any debug code, console logs, or commented-out code

    Add comments for complex logic or XML documentation (/// <summary>) for key methods

    *If Swagger exists Update Swagger/OpenAPI documentation for API changes 