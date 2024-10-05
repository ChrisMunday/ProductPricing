namespace PP.Data.Models;

public sealed class ProductPrice
{
    public ProductPrice(decimal price)
    {
        Price = price;
        Date = DateTime.UtcNow.ToString("yyyy-MM-dd");
    }

    public ProductPrice(decimal price, string date)
    {
        Price = price;
        Date = date;
    }

    public decimal Price { get; }

    public string Date { get; }
}

