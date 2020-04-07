using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Repositories;

namespace Todo.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
        
            return Ok(id);
        }
    }
}
