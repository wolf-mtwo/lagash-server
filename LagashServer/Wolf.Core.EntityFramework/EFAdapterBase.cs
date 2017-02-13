using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wolf.Core.Interfaces;

namespace Wolf.Core.EntityFramework
{
    public class EFAdapterBase<T> : IAdapterBase<T> where T : class
    {
        protected readonly DbContext context;

        protected EFAdapterBase(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T FindById(string id)
        {
            return context.Set<T>().Find(id);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector)
        {
            return context.Set<T>().OrderBy(keySelector).ToList();
        }

        public IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector)
        {
            return context.Set<T>().OrderByDescending(keySelector).ToList();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
