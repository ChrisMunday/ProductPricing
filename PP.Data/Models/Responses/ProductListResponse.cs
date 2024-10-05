namespace PP.Data.Models.Responses;

public sealed class ProductListResponse : List<ProductResponse>
{
	public ProductListResponse(IList<Product> products)
	{
		foreach (var product in products)
		{
			Add(new ProductResponse(product));
		}
	}
}
