using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void CreateTodo(TodoItem item);

        void UpdateTodo(TodoItem item);
        TodoItem GetById(Guid id, string user);
    }
}
