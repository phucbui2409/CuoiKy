using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuanLyBanHangOnline.WinForms.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
