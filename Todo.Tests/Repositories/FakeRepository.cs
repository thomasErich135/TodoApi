using System;
using Todo.Domain.Repositories;

namespace Todo.Tests.Repositories
{
    public class FakeRepository<T> : IRepository<T> where T : class
    {
        public void Dispose()
        {
            
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
