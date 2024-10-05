using PP.Data.Models.Responses;

namespace PP.Data.Interfaces;

public interface IProductHistoryFactory
{
    PriceHistoryResponse GetProductHistory(int id);
}
