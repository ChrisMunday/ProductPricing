namespace PP.Data.Models.Responses;

public sealed class PriceHistoryResponse
{
    public PriceHistoryResponse(Product product, ProductHistory productHistory)
    {
        Id = product.Id;
        Name = product.Name;
        PriceHistory = productHistory.PriceHistory;
    }

    public int Id { get; set; }

	public string Name { get; }

    public IEnumerable<ProductPrice> PriceHistory { get; }
}
