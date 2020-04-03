using System;

namespace Todo.Domain.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        int SaveChanges();
    }
}
