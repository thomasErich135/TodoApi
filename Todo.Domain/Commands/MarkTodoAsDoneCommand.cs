﻿using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsDoneCommand(){}
        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                   new Contract()
                       .Requires()
                       .IsNotEmpty(Id,"Id","Id não poder ser vazio!")
                       .HasMinLen(User, 6, "User", "Usuário inválido!")
               );
        }
    }
}
