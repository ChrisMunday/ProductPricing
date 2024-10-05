namespace PP.Data.Models;

public sealed class ProductHistory
{
    public ProductHistory(int id)
    {
        Id = id;
    }

    public int Id { get; }

    public List<ProductPrice> PriceHistory { get; set; } = new();

    public void AddPrice(decimal price)
    {
        PriceHistory.Insert(0, new ProductPrice(price));
    }

    public void AddPrice(decimal price, string date)
    {
        PriceHistory.Insert(0, new ProductPrice(price, date));
    }
}

