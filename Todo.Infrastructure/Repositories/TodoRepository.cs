using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Context;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        public TodoRepository(MysqlContext context) : base(context)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _dbSet.AsNoTracking()
                    .FirstOrDefault(p => p.Id == id && p.User == user);
        }
        public void UpdateTodo(TodoItem item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }
        public void CreateTodo(TodoItem item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

    }
}
