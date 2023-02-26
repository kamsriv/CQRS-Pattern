using DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UnitofWork : IUnitofWork
    {
        private readonly CQRSDContext _context;
        public IProductRepository ProductRepository { get; }
        //In our constructor creating the new class for each repository and assiging to the property that was available.
        public UnitofWork(CQRSDContext context) {
            _context = context;
            ProductRepository = new ProductRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
