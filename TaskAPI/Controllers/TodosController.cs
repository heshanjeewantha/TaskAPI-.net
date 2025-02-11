﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TaskAPI.Services.Todos;
using TaskAPI.Services.Models;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [Route("api/authors/{authorId}/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoRepository _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepository repository,IMapper mapper)
        {
            _todoService = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<TodoDto>> GetTodos(int authorId)
        {
            var myTodos = _todoService.AllTodos( authorId);
            var mappedTodos = _mapper.Map<ICollection<TodoDto>>(myTodos);

            return Ok(mappedTodos);
        }
        [HttpGet("{id}",Name ="GetTodo")]
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
        public ActionResult<TodoDto> CreateTodo(int authorId, createTodoDto todo) {

            var todoEntity =_mapper.Map<Todo>(todo);
            var newTodo =_todoService.AddTodo(authorId, todoEntity);

            var todoForReturn =_mapper.Map<TodoDto>(newTodo);
            return CreatedAtRoute("GetTodo", new { authorId = authorId, id = todoForReturn.Id }, todoForReturn);

        }


    }
}