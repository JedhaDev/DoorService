using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected RepositoryContext repositoryContext { get; set; }

        public BaseRepository(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.repositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.repositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.repositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.repositoryContext.Set<T>().AddOrUpdate(entity);
            repositoryContext.SaveChanges();

        }

        public void Delete(T entity)
        {
            this.repositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.repositoryContext.SaveChanges();
        }

    }

}
