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

        public IList<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IList<TodoItem> GetAllByPeriod(string user, bool done, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IList<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IList<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
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
