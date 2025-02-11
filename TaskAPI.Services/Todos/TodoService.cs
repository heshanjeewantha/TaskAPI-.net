using TaskAPI.Models;

namespace TaskAPI.Services.Todos
{
    public class TodoService : ITodoRepository
    {
        public List<Todo> AllTodos()
        {
            var todos = new List<Todo>();
            var todo1 = new Todo
            {
                Id = 1,
                Title = "Learn C#",
                Description = "Learn C# basics",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(30),
                Status = TodoStatus.New
            };
            todos.Add(todo1);

            var todo2 = new Todo
            {
                Id = 2,
                Title = "Learn ASP.NET Core",
                Description = "Learn ASP.NET Core basics",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(30),
                Status = TodoStatus.Completed
            };
            todos.Add(todo2);

            var todo3 = new Todo
            {
                Id = 3,
                Title = "Learn EF Core",
                Description = "Learn EF Core basics",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(30),
                Status = TodoStatus.New
            };
            todos.Add(todo3);

            return todos;
        }

        public Todo GetTodo(int id)
        {
            throw new NotImplementedException();
        }
    }
}