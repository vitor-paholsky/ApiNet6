﻿using ApiNet6.Data;
using ApiNet6.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet6.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List <TodoModel> Get([FromServices] AppDbContext context) 
        {
            return context.Todos.ToList();
        }

        [HttpGet("/{id:int}")]
        [Route("/")]
        public TodoModel GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("/")]
        public TodoModel Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return todo;
        }

        [HttpPut("/")]
        public TodoModel Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return todo;

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/")]
        public TodoModel Delete([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            context.Todos.Remove(model);
            context.SaveChanges();
            return model;
        }
    }
}
