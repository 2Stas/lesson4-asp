# SKILL ASPNETCoreBugFixing

## Purpose

```
This Skill diagnoses and fixes bugs in ASP.NET Core projects.

It analyzes compiler errors, runtime exceptions, HTTP errors, routing problems, model binding issues, validation errors, dependency injection problems, Entity Framework Core errors, database errors, and incorrect controller or service behavior.

The Skill fixes the root cause of the problem while preserving the existing project architecture, coding style, naming conventions, and functionality.
```

## When to use

```
Use this Skill when:

- An ASP.NET Core project does not compile.
- The application crashes at runtime.
- A controller action throws an exception.
- An API endpoint returns an incorrect response.
- A route does not work.
- Parameters are not passed correctly to a controller.
- Model binding does not work.
- Model validation fails unexpectedly.
- Dependency Injection cannot resolve a service.
- Entity Framework Core queries fail.
- Database operations do not work.
- Create, Read, Update, or Delete operations do not work.
- An HTTP status code is incorrect.
- A controller returns incorrect data.
- A service returns incorrect data.
- The user provides an ASP.NET Core error message or stack trace.
- The user asks to find and fix an ASP.NET Core bug.
```

## Context

```
The Skill operates within an existing ASP.NET Core project.

Relevant project areas include:

Controllers/
Models/
Services/
Interfaces/
Data/
wwwroot/
Program.cs
appsettings.json
appsettings.Development.json
*.csproj

The Skill may also inspect:

- Entity Framework Core DbContext
- Entity configurations
- Migrations
- Dependency Injection configuration
- Middleware
- Routing configuration
- DataAnnotations
- Service interfaces
- Repository classes
- API clients
- Configuration classes
```

## Inputs

```
The Skill may receive:

- Bug description
- Error message
- Exception type
- Stack trace
- Controller code
- Service code
- Model code
- DbContext code
- Program.cs
- appsettings.json
- Project structure
- URL that causes the problem
- HTTP method
- Request parameters
- Request body
- Expected result
- Actual result
- Steps to reproduce the bug

The Skill must inspect the existing project when additional information is available.
```

## Workflow

### 1. Analyze the Error

```
Identify:

- Exception type
- Error message
- HTTP status code
- Stack trace
- File name
- Line number
- Controller action
- Service method
- Database operation involved

Determine whether the problem is:

- Compilation
- Routing
- Controller
- Model binding
- Validation
- Dependency Injection
- Service
- Entity Framework Core
- Database
- Configuration
- Middleware
- Logic
```

### 2. Locate the Root Cause

```
Follow the execution path:

Request
    ↓
Routing
    ↓
Controller
    ↓
Service
    ↓
Entity Framework Core
    ↓
Database
    ↓
Controller
    ↓
HTTP Response

Find the first point where the actual behavior differs from the expected behavior.

Do not assume that the last exception in the stack trace is necessarily the original cause.
```

### 3. Inspect Existing Code

```
Before changing code, inspect:

- Related controller
- Related service
- Service interface
- Model
- DbContext
- Program.cs
- Routing configuration
- Similar working functionality

Compare broken code with existing working patterns.
```

### 4. Check ASP.NET Core Routing

```
Verify:

- Controller name
- [Route] attributes
- [HttpGet]
- [HttpPost]
- [HttpPut]
- [HttpDelete]
- [HttpPatch]
- Route parameters
- Query parameters
- Action names
- Endpoint URLs

Verify that the requested URL matches the controller's route configuration.
```

### 5. Check Model Binding

```
Verify:

- Route parameters
- Query parameters
- Request body
- Parameter names
- Data types
- [FromRoute]
- [FromQuery]
- [FromBody]
- [FromForm]

Make sure parameter names correspond between the request and controller action.
```

### 6. Check Validation

```
Inspect:

- [Required]
- [StringLength]
- [Range]
- [EmailAddress]
- [Compare]
- [RegularExpression]
- ModelState
- Validation attributes

Determine whether the validation rule or the input is causing the problem.
```

### 7. Check Dependency Injection

```
Verify:

- Service interface
- Service implementation
- Registration in Program.cs
- Constructor parameters
- Service lifetime

Example:

builder.Services.AddScoped<IOrderService, OrderService>();

Verify that the controller requests the same interface:

private readonly IOrderService orderService;
```

### 8. Check Entity Framework Core

```
Inspect:

- DbContext
- DbSet properties
- Entity relationships
- Primary keys
- Foreign keys
- LINQ queries
- Include()
- FirstOrDefault()
- Find()
- Add()
- Update()
- Remove()
- SaveChanges()
- SaveChangesAsync()

Check whether the database connection and required tables exist.
```

### 9. Check Business Logic

```
Verify:

- Conditions
- Loops
- Calculations
- Null handling
- CRUD logic
- Service methods
- Controller logic
- Return values

Compare the broken logic with similar working functionality in the project.
```

### 10. Apply the Minimal Fix

```
Change only the code necessary to fix the problem.

Do not rewrite unrelated controllers, services, models, or database code.

Preserve the existing architecture.
```

### 11. Validate the Fix

```
Verify:

- Project compiles.
- Application starts.
- Original error no longer occurs.
- Endpoint works.
- Correct data is returned.
- Existing functionality remains operational.
```

### 12. Explain the Fix

```
Explain:

- What caused the bug.
- Where the bug was located.
- What was changed.
- Why the change fixes the problem.
- How to test the fix.
```

## Rules

### General Rules

```
1. Always investigate the existing code before modifying it.

2. Fix the root cause instead of hiding the error.

3. Make the smallest reasonable change.

4. Do not rewrite the entire project.

5. Do not introduce unnecessary packages.

6. Do not change the project's architecture unless required.

7. Follow existing naming conventions.

8. Follow existing folder structure.

9. Follow existing coding style.

10. Never invent classes, methods, services, database tables, or configuration that do not exist.
```

### Controller Rules

```
Check that:

- Controller names end with Controller.
- Routes match the intended URL.
- HTTP method attributes are correct.
- Action parameters match route/query/body parameters.
- Return types are appropriate.

For APIs:

return Ok(data);

return Created(...);

return BadRequest(...);

return NotFound(...);

return Unauthorized();

return Forbid();
```

### Routing Rules

```
Verify the relationship between:

[Route("api/[controller]")]

[HttpGet]

[HttpGet("{id}")]

[HttpPost]

[HttpPut("{id}")]

[HttpDelete("{id}")]

[HttpPatch("{id}")]

and the actual requested URL.

Never change routes unnecessarily if the existing route is correct.
```

### Model Binding Rules

```
Route parameters must correspond to route templates.

Example:

[HttpGet("{id}")]

public IActionResult GetById(int id)

The URL:

/api/Order/5

must provide the value for:

id

Query parameters must correspond to action parameters.

Request body parameters must correspond to the expected model or object structure.
```

### Service Rules

```
If a controller uses a service:

Controller
    ↓
Service Interface
    ↓
Service Implementation

Keep business logic in the existing service layer when the project already uses one.

Do not move logic between Controller and Service unless necessary to fix the bug.
```

### Entity Framework Rules

```
Check whether queries can return null.

Example:

Order order = orderService.GetById(id);

if (order == null)
{
    return NotFound();
}

Do not use null-forgiving operators simply to suppress warnings when null is a real possibility.

Check that SaveChanges() is called after modifications when required.
```

### Dependency Injection Rules

```
If ASP.NET Core reports:

Unable to resolve service for type ...

Check:

1. Interface
2. Implementation
3. Program.cs registration
4. Constructor injection

Example:

builder.Services.AddScoped<IOrderService, OrderService>();
```

### Error Handling Rules

```
Do not use:

catch
{
}

Do not silently ignore exceptions.

If an exception must be caught, preserve useful information and follow the project's existing error-handling pattern.
```

## Existing Patterns

```
The Skill must use existing working code as the primary reference.

Examples:

If the project uses:

Controller → Service

continue using:

Controller → Service

If the project uses:

Controller → DbContext

do not introduce a Repository pattern just to fix one bug.

If the project has several working CRUD methods, use their structure when fixing another CRUD method.

If existing controllers use specific route conventions, follow the same conventions.

If existing services use interfaces, continue using interfaces.
```

## Validations

### Build Validation

```
Verify:

- No compilation errors.
- No missing namespaces.
- No missing references.
- No invalid method signatures.
- No invalid types.
```

### Application Validation

```
Verify:

- Application starts.
- Required middleware is configured.
- Required services are registered.
- The affected URL can be accessed.
```

### Controller Validation

```
Verify:

- Correct route.
- Correct HTTP method.
- Correct parameters.
- Correct return type.
- Correct status code.
```

### Database Validation

```
Verify:

- DbContext is configured.
- Connection string is valid.
- Database is accessible.
- Required entities exist.
- Queries return expected results.
- SaveChanges() is executed when required.
```

### Regression Validation

```
Verify that the fix does not break:

- Other controller actions.
- Existing CRUD operations.
- Existing services.
- Existing database operations.
```

## Output

```
The response must contain:

### Root Cause

A short explanation of the actual cause of the bug.

### Fix

The corrected code.

### Changed Files

A list of files that need to be changed.

### Explanation

A simple explanation of why the correction works.

### Validation

Steps for testing the fix.

When possible, provide the complete corrected method rather than unrelated parts of the project.

If several files must be changed, separate the code by file.

Do not output unrelated code.
```

## Examples

### Example 1 — Dependency Injection Error

```
Error:

InvalidOperationException:
Unable to resolve service for type 'IOrderService'.

Controller:

public OrderController(IOrderService orderService)
{
    this.orderService = orderService;
}

Diagnosis:

IOrderService is required by the controller but has not been registered.

Check Program.cs.

Fix:

builder.Services.AddScoped<IOrderService, OrderService>();

Validation:

Restart the application and open the affected controller route.
```

### Example 2 — Incorrect Route Parameter

```
Controller:

[HttpGet("GetById/{id}")]
public IActionResult GetById(int id)
{
    Order order = orderService.GetById(id);

    if (order == null)
    {
        return NotFound();
    }

    return Ok(order);
}

If the requested URL is:

/api/Order/GetById/5

the route parameter must be:

id

The controller parameter must also be:

int id

Do not rename the parameter unless the route is changed accordingly.
```

### Example 3 — Null Entity

```
Problem:

The application throws NullReferenceException when an order does not exist.

Incorrect:

Order order = orderService.GetById(id);

order.Status = "Completed";

orderService.Update(order);

Correct:

Order order = orderService.GetById(id);

if (order == null)
{
    return NotFound();
}

order.Status = "Completed";

orderService.Update(order);

Explanation:

GetById can return null when the order does not exist. The controller must handle this case before accessing the object.
```

### Example 4 — Entity Framework Query Bug

```
Problem:

An entity cannot be found even though it exists in the database.

Existing query:

Order order = context.Orders
    .FirstOrDefault(o => o.Id == id);

Check:

- Correct DbContext
- Correct DbSet
- Correct ID
- Correct connection string
- Database availability
- Database migrations
- Query conditions

If the query condition is incorrect, fix the condition rather than changing the entire database layer.
```

### Example 5 — Incorrect Update

```
Problem:

UpdateStatus receives an order ID but the service cannot find the order.

Example:

[HttpPost("UpdateStatus/{id}")]
public IActionResult UpdateStatus(int id, string status)
{
    Order order = orderService.GetById(id);

    if (order == null)
    {
        return NotFound();
    }

    order.Status = status;

    orderService.Update(order);

    return Ok(order);
}

Check that the same ID is passed through:

URL:
/Order/UpdateStatus/5

Controller:
int id

Service:
GetById(id)

Entity:
order.Id
```

### Example 6 — Model Validation Bug

```
Model:

public class UserModel
{
    [Required]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}

Controller:

[HttpPost]
public IActionResult Create(UserModel model)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // Save model

    return Ok(model);
}

If validation unexpectedly fails, inspect:

- Request property names
- Model property names
- DataAnnotations
- Posted values
- ModelState errors

Do not remove validation attributes just to make the request succeed.
```

### Example 7 — Minimal Bug Fix

```
Problem:

Existing code:

public IActionResult Delete(int id)
{
    Order order = orderService.GetById(id);

    orderService.Delete(order);

    return Ok();
}

Error:

NullReferenceException when an invalid ID is provided.

Minimal fix:

public IActionResult Delete(int id)
{
    Order order = orderService.GetById(id);

    if (order == null)
    {
        return NotFound();
    }

    orderService.Delete(order);

    return Ok();
}

Do not rewrite the controller, service, model, or database layer when this null check is sufficient.
```
