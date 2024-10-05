using PP.Data.Interfaces.Async;
using PP.Data.Models.Responses;

namespace PP.Data.Factories;

public class ProductFactoryAsync : ProductFactory, IProductFactoryAsync, IProductHistoryFactoryAsync
{
    public async Task<ProductListResponse> GetProductsAsync(CancellationToken cancellationToken)
    {
        return await Task.Run(() => { return GetProducts(); }, cancellationToken);
    }

    public async Task<PriceHistoryResponse> GetProductHistoryAsync(int id, CancellationToken cancellationToken)
    {
        return await Task.Run(() => { return GetProductHistory(id); }, cancellationToken);
    }

    public async Task<DiscountResponse> ApplyDiscountAsync(int id, decimal discountPercentage, CancellationToken cancellationToken)
    {
        return await Task.Run(() => { return ApplyDiscount(id, discountPercentage); }, cancellationToken);
    }

    public async Task<NewPriceResponse> UpdatePriceAsync(int id, decimal newPrice, CancellationToken cancellationToken)
    {
        return await Task.Run(() => { return UpdatePrice(id, newPrice); }, cancellationToken);
    }
}
