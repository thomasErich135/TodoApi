using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository : IRepository<TodoItem>
    {
        void CreateTodo(TodoItem item);
        void UpdateTodo(TodoItem item);
        TodoItem GetById(Guid id, string user);
        IList<TodoItem> GetAll(string user);
        IList<TodoItem> GetAllDone(string user);
        IList<TodoItem> GetAllUndone(string user);
        IList<TodoItem> GetAllByPeriod(string user, bool done, DateTime date);
        
    }
}
