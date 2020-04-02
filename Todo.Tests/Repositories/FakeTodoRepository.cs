using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void CreateTodo(TodoItem item)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo da tarefa", DateTime.Now, "Usuário de Teste");
        }

        public void UpdateTodo(TodoItem item)
        {
        }
    }
}
