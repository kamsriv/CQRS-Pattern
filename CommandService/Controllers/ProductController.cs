using CommandService.Commands.Handlers;
using CommandService.Commands.Interfaces;
using CommandService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    public class ProductController : Controller
    {
        IProductCommand _command;
        public ProductController(IProductCommand command) {
            _command = command;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct(ProductCommandModel model)
        {
            try
            {
                await _command.AddProdctCommandAsync(model);
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, model);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProduct(ProductCommandModel model)
        {
            try
            {
                await _command.UpdateProductCommandAsync(model);
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, model);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _command.DeleteProductCommandAsync(id);
                return StatusCode(StatusCodes.Status201Created, id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, id);
            }
        }
    }
}
