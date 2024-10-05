namespace PP.Data.Models.Responses;

public sealed class NewPriceResponse
{
    public NewPriceResponse(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        NewPrice = product.Price;
        LastUpdated = product.LastUpdated;
    }

	public int Id { get; }

    public string Name { get; }

    public decimal NewPrice { get; }

    public string LastUpdated { get; }
}
