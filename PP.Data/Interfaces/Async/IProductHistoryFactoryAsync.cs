using PP.Data.Models.Responses;

namespace PP.Data.Interfaces.Async;

public interface IProductHistoryFactoryAsync
{
    Task<PriceHistoryResponse> GetProductHistoryAsync(int id, CancellationToken cancellationToken);
}
