using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Context;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _dbSet.AsNoTracking()
                    .FirstOrDefault(p => p.Id == id && p.User == user);
        }
        public void UpdateTodo(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void CreateTodo(TodoItem item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public IList<TodoItem> GetAll(string user)
        {
            return _dbSet.AsNoTracking()
                .Where(TodoQueries.GetAll(user)).OrderBy(x => x.Date).ToList();
        }

        public IList<TodoItem> GetAllDone(string user)
        {
            return _dbSet.AsNoTracking()
                .Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Date).ToList();
        }

        public IList<TodoItem> GetAllUndone(string user)
        {
            return _dbSet.AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user)).OrderBy(x => x.Date).ToList();
        }

        public IList<TodoItem> GetAllByPeriod(string user, bool done, DateTime date)
        {
            return _dbSet.AsNoTracking()
                .Where(TodoQueries.GetAllByPeriod(user,done,date)).OrderBy(x => x.Title).ToList();
        }
    }
}
