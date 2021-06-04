using System;
using System.Collections.Generic;

namespace AdventureWorks.Core.Abstractions.Repositories
{
    public interface IRepositoryBase<T>
        where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entityes);
        void Remove(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetSingle(Func<T, bool> predicate);
        T Get(int id);
    }
}
