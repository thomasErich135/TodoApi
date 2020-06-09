using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Application.Controllers
{
    [ApiController]
    [Authorize]
    [Route("v1/todos")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        private readonly TodoHandler _handler;
        public TodoController(ITodoRepository repository, TodoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        //Cria uma tarefa
        [Route("create")]
        [HttpPut]
        public IActionResult Create([FromBody]CreateTodoCommand commandTodo)
        {
            try
            {
                commandTodo.User = "marcelo@gmail.com";

                return Ok((GenericCommandResult)_handler.Handle(commandTodo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Pega todas a tarefas do usuário
        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repository.GetAll("marcelo@gmail.com"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Lista tarefas feitas
        [Route("get-all-done")]
        [HttpGet]
        public IActionResult GetAllDone()
        {
            try
            {
                return Ok(_repository.GetAllDone("marcelo@gmail.com"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Lista tarefas não feitas
        [Route("get-all-undone")]
        [HttpGet]
        public IActionResult GetAllUndone()
        {
            try
            {
                return Ok(_repository.GetAllUndone("marcelo@gmail.com"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //TODO: Lista tarefas pela data(feitas(DEFAULT) ou não feitas)
        [Route("get-by-period")]
        [HttpGet]
        public IActionResult GetByPeriod(DateTime date, bool done = true)
        {
            try
            {
                return Ok(_repository.GetAllByPeriod("marcelo@gmail.com",done,date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //TODO: Atualiza uma tarefa

        //TODO: Marca tarefa como feita

        //TODO:Marca tarefa como não feita
    }
}
