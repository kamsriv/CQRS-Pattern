using DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields

        private readonly CQRSDContext _context;

        #endregion

        #region Ctor
        
        public Repository(CQRSDContext context)
        {
            _context = context;
        }

        public T Add(T modal)
        {
            _context.Set<T>().Add(modal);
            return modal;
        }

        public void Delete(T modal)
        {
            _context.Set<T>().Remove(modal);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T modal)
        {
            _context.Set<T>().Update(modal);
        }
        #endregion

    }
}