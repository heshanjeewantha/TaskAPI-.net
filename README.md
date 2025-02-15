<h1>TaskAPI - .NET Web API</h1>

<h2>Overview</h2>
<p>This repository contains a .NET Web API for managing tasks (todos) associated with authors. The API provides CRUD operations for todos, including search and filter functionality. It uses AutoMapper for object mapping and follows RESTful principles. The project is structured to ensure scalability and maintainability.</p>

<h2>Features</h2>
<ul>
  <li><strong>RESTful API:</strong> Follows REST conventions for managing todos.</li>
  <li><strong>AutoMapper:</strong> Simplifies object-to-object mapping between entities and DTOs.</li>
  <li><strong>Search and Filter:</strong> Built-in functionality to retrieve todos based on author ID.</li>
  <li><strong>CRUD Operations:</strong> Create, Read, Update, and Delete todos.</li>
  <li><strong>Dependency Injection:</strong> Uses .NET's built-in DI for service management.</li>
  <li><strong>Validation:</strong> Ensures data integrity through model validation.</li>
</ul>

<h2>Prerequisites</h2>
<p>Before running the project, ensure you have the following installed:</p>
<ul>
  <li>.NET SDK (version 6.0 or later)</li>
  <li>Visual Studio or Visual Studio Code</li>
  <li>SQL Server or another database supported by EF Core</li>
</ul>

<h2>Getting Started</h2>

<h3>Clone the Repository</h3>
<pre><code>git clone https://github.com/heshanjeewantha/TaskAPI-.net.git
cd TaskAPI-.net</code></pre>

<h3>Restore Dependencies</h3>
<pre><code>dotnet restore</code></pre>

<h3>Configure the Database</h3>
<p>Update the connection string in <code>appsettings.json</code> with your database details.</p>
<p>Run the following commands to apply migrations:</p>
<pre><code>dotnet ef database update</code></pre>

<h3>Run the Application</h3>
<pre><code>dotnet run</code></pre>
<p>The API will be available at <a href="https://localhost:5001">https://localhost:5001</a> (or <a href="http://localhost:5000">http://localhost:5000</a>).</p>

<h3>Explore the API</h3>
<p>Open the Swagger UI in your browser by navigating to <a href="https://localhost:5001/swagger">https://localhost:5001/swagger</a>.</p>

<h2>API Endpoints</h2>

<h3>Todos Controller</h3>

<h4>Get Todos for an Author</h4>
<p><strong>GET /api/authors/{authorId}/todos</strong></p>
<p>Retrieves all todos for a specific author.</p>

<h4>Get a Specific Todo</h4>
<p><strong>GET /api/authors/{authorId}/todos/{id}</strong></p>
<p>Retrieves a specific todo by its ID for a given author.</p>

<h4>Create a Todo</h4>
<p><strong>POST /api/authors/{authorId}/todos</strong></p>
<p>Creates a new todo for a specific author.</p>

<h4>Update a Todo</h4>
<p><strong>PUT /api/authors/{authorId}/todos/{todoId}</strong></p>
<p>Updates an existing todo for a specific author.</p>

<h4>Delete a Todo</h4>
<p><strong>DELETE /api/authors/{authorId}/todos/{todoId}</strong></p>
<p>Deletes a todo for a specific author.</p>

<h2>Project Structure</h2>
<pre><code>.
├── Controllers/          # API controllers
│   └── TodosController.cs
├── Models/               # Data models and entities
├── Services/             # Business logic and service layer
│   └── Todos/            # Todo-related services
├── DTOs/                 # Data transfer objects
├── appsettings.json      # Application settings
├── Program.cs            # Entry point
└── Startup.cs            # Startup configuration (if applicable)
</code></pre>

<h2>Dependencies</h2>
<ul>
  <li><strong>AutoMapper:</strong> For object-to-object mapping.</li>
  <li><strong>Entity Framework Core:</strong> For database operations.</li>
  <li><strong>Swagger/OpenAPI:</strong> For API documentation.</li>
  <li><strong>Microsoft.AspNetCore.Mvc:</strong> For building the API.</li>
</ul>

<h2>Code Example</h2>
<h3>TodosController.cs</h3>
<pre><code>using AutoMapper;
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
        public ActionResult&lt;ICollection&lt;TodoDto&gt;&gt; GetTodos(int authorId)
        {
            var myTodos = _todoService.AllTodos(authorId);
            var mappedTodos = _mapper.Map&lt;ICollection&lt;TodoDto&gt;&gt;(myTodos);
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
            var mappedTodo = _mapper.Map&lt;TodoDto&gt;(todo);
            return Ok(mappedTodo);
        }

        [HttpPost]
        public ActionResult&lt;TodoDto&gt; CreateTodo(int authorId, CreateTodoDto todo)
        {
            var todoEntity = _mapper.Map&lt;Todo&gt;(todo);
            var newTodo = _todoService.AddTodo(authorId, todoEntity);
            var todoForReturn = _mapper.Map&lt;TodoDto&gt;(newTodo);
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
</code></pre>

<h2>Contributing</h2>
<p>We welcome contributions! Please follow these steps:</p>
<ol>
  <li>Fork the repository.</li>
  <li>Create a new branch (<code>git checkout -b feature/YourFeatureName</code>).</li>
  <li>Commit your changes (<code>git commit -m 'Add some feature'</code>).</li>
  <li>Push to the branch (<code>git push origin feature/YourFeatureName</code>).</li>
  <li>Open a pull request.</li>
</ol>

<h2>License</h2>
<p>This project is licensed under the MIT License. See the <a href="LICENSE">LICENSE</a> file for details.</p>

<h2>Support</h2>
<p>If you encounter any issues or have questions, please open an issue on GitHub or contact the maintainers.</p>

<p>Happy coding! 🚀</p>
