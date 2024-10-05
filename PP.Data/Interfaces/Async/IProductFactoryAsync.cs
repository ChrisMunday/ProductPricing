using PP.Data.Models.Responses;

namespace PP.Data.Interfaces.Async;

public interface IProductFactoryAsync
{
    Task<ProductListResponse> GetProductsAsync(CancellationToken cancellationToken);

    Task<DiscountResponse> ApplyDiscountAsync(int id, decimal discountPercentage, CancellationToken cancellationToken);

    Task<NewPriceResponse> UpdatePriceAsync(int id, decimal newPrice, CancellationToken cancellationToken);
}
