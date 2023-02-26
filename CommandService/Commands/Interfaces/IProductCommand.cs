using CommandService.Models;
namespace CommandService.Commands.Interfaces
{
    public interface IProductCommand
    {
        Task<ProductCommandModel> AddProdctCommandAsync(ProductCommandModel model);
        Task<bool> UpdateProductCommandAsync(ProductCommandModel model);
        Task<bool> DeleteProductCommandAsync(int Id);
    }
}
