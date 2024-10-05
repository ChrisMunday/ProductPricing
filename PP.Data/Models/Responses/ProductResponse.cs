namespace PP.Data.Models.Responses;

public sealed class ProductResponse
{
	public ProductResponse(Product product)
	{
        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
        LastUpdated = product.LastUpdated;
	}

    public int Id { get; }

    public string Name { get; }

    public decimal Price { get; }

    public string LastUpdated { get; }
}
