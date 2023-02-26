using CommandService.Commands.Interfaces;
using CommandService.Models;
using DataModel;

namespace CommandService.Commands.Handlers
{
    public class ProductCommand : IProductCommand
    {
        CQRSDContext _context;
        public ProductCommand(CQRSDContext context) {
            _context = context;
        }
        public async Task<ProductCommandModel> AddProdctCommandAsync(ProductCommandModel model)
        {
            Product product = new Product()
            {
                Price= model.Price,
                ProductDescription= model.ProductDescription,  
                ProductName= model.ProductName
            };
            _context.Add(product);
            await _context.SaveChangesAsync();
            model.ProductId= product.ProductId;
            return model;
        }

        public async Task<bool> DeleteProductCommandAsync(int Id)
        {
           Product product = _context.Products.Find(Id);
           if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProductCommandAsync(ProductCommandModel model)
        {
            Product product = _context.Products.Find(model.ProductId);
            if (product != null)
            {
                product.Price = model.Price;
                product.ProductDescription = model.ProductDescription;
                product.ProductName = model.ProductName;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
