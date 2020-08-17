using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Wolf.Core.Interfaces
{
    public interface IAdapterBase<T>
    {   
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        T FindOne(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        T FindById(String id);
        IEnumerable<T> GetAll();
        IEnumerable<T> get_desc(Func<T, bool> where, Func<T, object> order);
        IEnumerable<T> get_asc(Func<T, bool> where, Func<T, object> order);
        IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector);
        IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector);
        IEnumerable<T> GetPage(int page, int limit, Func<T, object> keySelector);
        IEnumerable<T> Where(int page, int limit, Func<T, bool> where, Func<T, object> selector);
        int Count();
        T Create(T entity);
        void Update(T entity);
        T Delete(T entity);
        void Commit();
        void discart(T entity);
        void Dispose();
    }
}
