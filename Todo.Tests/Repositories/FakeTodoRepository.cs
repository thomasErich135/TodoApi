using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Tests.Repositories
{
    public class FakeTodoRepository : FakeRepository<TodoItem>, ITodoRepository
    {
        public void CreateTodo(TodoItem item)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Titulo Fake",DateTime.Now,"Usuário Fake");
        }

        public void UpdateTodo(TodoItem item)
        {
        }
    }
}
