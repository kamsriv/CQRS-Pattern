using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataModel.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T Add(T modal);
        void Update(T modal);
        void Delete(T modal);     
        T Get(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}
