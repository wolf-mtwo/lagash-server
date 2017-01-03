using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wargos.Core.Interfaces;

namespace Wargos.Core.EntityFramework
{
    public class EFAdapterBase<T> : IAdapterBase<T> where T : class
    {
        protected readonly DbContext Context;

        protected EFAdapterBase()
        {
            Context = new DbContext("LagashContext");
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector)
        {
            return Context.Set<T>().OrderBy(keySelector).ToList();
        }

        public IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector)
        {
            return Context.Set<T>().OrderByDescending(keySelector).ToList();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
