using System;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TodoController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(id);
        }
    }
}
