using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeManagementChallenge.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,string includeProperties = null,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);        
        T Get(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        int Save();
    }
}
