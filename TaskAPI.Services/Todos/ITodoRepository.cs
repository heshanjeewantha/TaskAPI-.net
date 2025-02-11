using System;
using TaskAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAPI.Services.Todos
{
    public interface ITodoRepository
    {
        List<Todo> AllTodos(int authorId);
        Todo GetTodo(int authorId, int id);
        Todo AddTodo(int authorId, Todo todo);
        void UpdateTodo(Todo updatingTodo);
        void DeleteTodo(Todo deletingTodo);
    }
}
