using DataModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    //All the generic implementations will be done at the generic Repository concrete implementation.
    //In case of any additional functionality we can define at the IProductRepository
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(CQRSDContext context) :base(context) { }
    }
}
