using Microsoft.AspNetCore.Mvc;
using PP.Data.Interfaces.Async;
using PP.Data.Models.Requests;

namespace PP.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFactoryAsync _productFactory;
        private readonly IProductHistoryFactoryAsync _productHistoryFactory;

        public ProductsController(IProductFactoryAsync productFactory, IProductHistoryFactoryAsync productHistoryFactory)
        {
            _productFactory = productFactory;
            _productHistoryFactory = productHistoryFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            try
            {
                var e = await _productFactory.GetProductsAsync(cancellationToken);
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductHistory(int id, CancellationToken cancellationToken)
        {
            try
            {
                var e = await _productHistoryFactory.GetProductHistoryAsync(id, cancellationToken);
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/apply-discount")]
        public async Task<IActionResult> ApplyDiscount(int id, DiscountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var e = await _productFactory.ApplyDiscountAsync(id, request.DiscountPercentage, cancellationToken);
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}/update-price")]
        public async Task<IActionResult> UpdatePrice(int id, NewPriceRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var e = await _productFactory.UpdatePriceAsync(id, request.NewPrice, cancellationToken);
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
