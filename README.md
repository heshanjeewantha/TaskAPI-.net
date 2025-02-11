#TaskAPI - .NET Web API
Overview
This repository contains a .NET Web API for managing tasks (todos) associated with authors. The API provides CRUD operations for todos, including search and filter functionality. It uses AutoMapper for object mapping and follows RESTful principles. The project is structured to ensure scalability and maintainability.

Features
RESTful API: Follows REST conventions for managing todos.

AutoMapper: Simplifies object-to-object mapping between entities and DTOs.

Search and Filter: Built-in functionality to retrieve todos based on author ID.

CRUD Operations: Create, Read, Update, and Delete todos.

Dependency Injection: Uses .NET's built-in DI for service management.

Validation: Ensures data integrity through model validation.

Prerequisites
Before running the project, ensure you have the following installed:

.NET SDK (version 6.0 or later)

Visual Studio or Visual Studio Code

SQL Server or another database supported by EF Core

Getting Started
Clone the Repository

bash
Copy
git clone https://github.com/heshanjeewantha/TaskAPI-.net.git
cd TaskAPI-.net
Restore Dependencies

bash
Copy
dotnet restore
Configure the Database

Update the connection string in appsettings.json with your database details.

Run the following commands to apply migrations:

bash
Copy
dotnet ef database update
Run the Application

bash
Copy
dotnet run
The API will be available at https://localhost:5001 (or http://localhost:5000).

Explore the API

Open the Swagger UI in your browser by navigating to https://localhost:5001/swagger.

API Endpoints
Todos Controller
Get Todos for an Author

GET /api/authors/{authorId}/todos

Retrieves all todos for a specific author.

Get a Specific Todo

GET /api/authors/{authorId}/todos/{id}

Retrieves a specific todo by its ID for a given author.

Create a Todo

POST /api/authors/{authorId}/todos

Creates a new todo for a specific author.

Update a Todo

PUT /api/authors/{authorId}/todos/{todoId}

Updates an existing todo for a specific author.

Delete a Todo

DELETE /api/authors/{authorId}/todos/{todoId}

Deletes a todo for a specific author.

Project Structure
Copy
.
├── Controllers/          # API controllers
│   └── TodosController.cs
├── Models/               # Data models and entities
├── Services/             # Business logic and service layer
│   └── Todos/            # Todo-related services
├── DTOs/                 # Data transfer objects
├── appsettings.json      # Application settings
├── Program.cs            # Entry point
└── Startup.cs            # Startup configuration (if applicable)
Dependencies
AutoMapper: For object-to-object mapping.

Entity Framework Core: For database operations.

Swagger/OpenAPI: For API documentation.

Microsoft.AspNetCore.Mvc: For building the API.

Code Example
TodosController.cs
csharp
Copy
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Todos;
using TaskAPI.Services.Models;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [Route("api/authors/{authorId}/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepository repository, IMapper mapper)
        {
            _todoService = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<TodoDto>> GetTodos(int authorId)
        {
            var myTodos = _todoService.AllTodos(authorId);
            var mappedTodos = _mapper.Map<ICollection<TodoDto>>(myTodos);
            return Ok(mappedTodos);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetTodo(int authorId, int id)
        {
            var todo = _todoService.GetTodo(authorId, id);
            if (todo is null)
            {
                return NotFound();
            }
            var mappedTodo = _mapper.Map<TodoDto>(todo);
            return Ok(mappedTodo);
        }

        [HttpPost]
        public ActionResult<TodoDto> CreateTodo(int authorId, CreateTodoDto todo)
        {
            var todoEntity = _mapper.Map<Todo>(todo);
            var newTodo = _todoService.AddTodo(authorId, todoEntity);
            var todoForReturn = _mapper.Map<TodoDto>(newTodo);
            return CreatedAtRoute("GetTodo", new { authorId = authorId, id = todoForReturn.Id }, todoForReturn);
        }

        [HttpPut("{todoId}")]
        public ActionResult UpdateTodo(int authorId, int todoId, UpdateTodoDto todo)
        {
            var updatingTodo = _todoService.GetTodo(authorId, todoId);
            if (updatingTodo is null)
            {
                return NotFound();
            }
            _mapper.Map(todo, updatingTodo);
            _todoService.UpdateTodo(updatingTodo);
            return NoContent();
        }

        [HttpDelete("{todoId}")]
        public ActionResult DeleteTodo(int authorId, int todoId)
        {
            var deletingTodo = _todoService.GetTodo(authorId, todoId);
            if (deletingTodo is null)
            {
                return NotFound();
            }
            _todoService.DeleteTodo(deletingTodo);
            return NoContent();
        }
    }
}
Contributing
We welcome contributions! Please follow these steps:

Fork the repository.

Create a new branch (git checkout -b feature/YourFeatureName).

Commit your changes (git commit -m 'Add some feature').

Push to the branch (git push origin feature/YourFeatureName).

Open a pull request.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Support
If you encounter any issues or have questions, please open an issue on GitHub or contact the maintainers.

Happy coding! 🚀

