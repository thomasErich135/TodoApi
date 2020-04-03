using System;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Context;

namespace Todo.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MysqlContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(MysqlContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
