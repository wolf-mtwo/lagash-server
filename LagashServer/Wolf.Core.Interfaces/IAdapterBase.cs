using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wolf.Core.Interfaces
{
    public interface IAdapterBase<T>
    {
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        T FindOne(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        T FindById(String id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector);
        IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
        void Dispose();
    }
}
