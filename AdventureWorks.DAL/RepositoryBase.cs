using AdventureWorks.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected readonly AdventureWorksLT2012Context Context;
        public RepositoryBase(AdventureWorksLT2012Context dbContext)
        {
            Context = dbContext;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entityes)
        {
            Context.Set<T>().AddRange(entityes);
        }
        public T Get(int id)
        {
            var entity = Context.Set<T>().Find(id);
            return entity;
        }
        public IEnumerable<T> GetAll()
        {
            var entities = Context.Set<T>().ToArray();
            return entities;
        }
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
        public T GetSingle(Func<T, bool> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }
    }
}
