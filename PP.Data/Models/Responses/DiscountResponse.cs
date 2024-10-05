namespace PP.Data.Models.Responses;

public sealed class DiscountResponse
{
	public DiscountResponse(Product product)
	{
        Id = product.Id;
        Name = product.Name;
        DiscountedPrice = product.DiscountedPrice;
        OriginalPrice = product.OriginalPrice;
	}

    public int Id { get; }

    public string Name { get; }

    public decimal DiscountedPrice { get; }

    public decimal OriginalPrice { get; }
}
