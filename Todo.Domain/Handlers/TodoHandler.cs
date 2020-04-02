﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo deu errado!",
                    command.Notifications);

            //Gera o TodoItem
            var todo = new TodoItem(command.Title,command.Date,command.User);

            //Salvar no banco
            _repository.CreateTodo(todo);

            return new GenericCommandResult(
                    true,
                    "Tarefa salva!",
                    todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo deu errado!",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.UpdateTodo(todo);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada com sucesso!",
                todo);

        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo deu errado!",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.UpdateTodo(todo);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada com sucesso!",
                todo);

        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo deu errado!",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.UpdateTodo(todo);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada com sucesso!",
                todo);
        }
    }
}
