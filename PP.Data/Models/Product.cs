namespace PP.Data.Models;

public sealed class Product
{
    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
        LastUpdated = DateTime.UtcNow.ToString("s");
    }

    public Product(int id, string name, decimal price, string date)
    {
        Id = id;
        Name = name;
        Price = price;
        LastUpdated = date;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public decimal DiscountedPrice { get; set; }

    public decimal OriginalPrice { get; set; }

    public string LastUpdated { get; set; }
}

