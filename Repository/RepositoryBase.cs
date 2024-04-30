using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SchoolDBContext SchoolDBContext { get; set; }
        public RepositoryBase(SchoolDBContext repositoryContext)
        {
            SchoolDBContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => SchoolDBContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            SchoolDBContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => SchoolDBContext.Set<T>().Add(entity);

        public void Update(T entity) => SchoolDBContext.Set<T>().Update(entity);

        public void Delete(T entity) => SchoolDBContext.Set<T>().Remove(entity);
    }
}
