﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskAPI.Models;
using TaskAPI.Services.Models;

namespace TaskAPI.Services.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>();
            CreateMap<createTodoDto, Todo>();
            CreateMap<UpdateTodoDto, Todo>();
        }
    }
}
