using PP.Data.Interfaces;
using PP.Data.Models;
using PP.Data.Models.Responses;

namespace PP.Data.Factories;

public class ProductFactory : IProductFactory, IProductHistoryFactory
{
    // Mock Database Repositories
    static readonly List<Product> ProductRepo = new();
    static readonly List<ProductHistory> ProductHistoryRepo = new();

    static ProductFactory()
	{
        SeedRepos();
	}

    private static void SeedRepos()
    {
        // Products
        ProductRepo.Add(new Product(1, "Product A", 100M, "2024-09-26T12:34:56"));
        ProductRepo.Add(new Product(2, "Product B", 200M, "2024-09-25T10:12:34"));

        // Product History
        var productHistory = new ProductHistory(1)
        {
            PriceHistory = new List<ProductPrice>
            {
                new ProductPrice(120M, "2024-09-01"),
                new ProductPrice(110M, "2024-08-15"),
                new ProductPrice(100M, "2024-08-10")
            }
        };
        ProductHistoryRepo.Add(productHistory);
    }

    public ProductListResponse GetProducts()
    {
        // Get Products
        return new ProductListResponse(ProductRepo);
    }

    public PriceHistoryResponse GetProductHistory(int id)
    {
        // Get Product
        var product = ProductRepo.SingleOrDefault(q => q.Id == id) ?? throw new Exception($"Product not found: ID = {id}");

        // Get Product History
        var productHistory = ProductHistoryRepo.SingleOrDefault(q => q.Id == id) ?? new ProductHistory(id);

        return new PriceHistoryResponse(product, productHistory);
    }

    public DiscountResponse ApplyDiscount(int id, decimal discountPercentage)
    {
        // Get Product
        var product = ProductRepo.SingleOrDefault(q => q.Id == id) ?? throw new Exception($"Product not found: ID = {id}");

        // Calculate New Price
        var originalPrice = product.Price;
        var discountedPrice = originalPrice * (100M - discountPercentage) / 100M;

        // Update Product
        product.Price = discountedPrice;
        product.OriginalPrice = originalPrice;
        product.DiscountedPrice = discountedPrice;
        product.LastUpdated = DateTime.UtcNow.ToString("s");

        // Update Product History
        var productHistory = ProductHistoryRepo.SingleOrDefault(q => q.Id == id);
        if (productHistory == null)
        {
            productHistory = new ProductHistory(id);
            ProductHistoryRepo.Add(productHistory);
        }
        productHistory.AddPrice(product.DiscountedPrice);

        return new DiscountResponse(product);
    }

    public NewPriceResponse UpdatePrice(int id, decimal newPrice)
    {
        // Get Product
        var product = ProductRepo.SingleOrDefault(q => q.Id == id) ?? throw new Exception($"Product not found: ID = {id}");

        // Update Product
        product.Price = newPrice;
        product.LastUpdated = DateTime.UtcNow.ToString("s");

        // Update Product History
        var productHistory = ProductHistoryRepo.SingleOrDefault(q => q.Id == id);
        if (productHistory == null)
        {
            productHistory = new ProductHistory(id);
            ProductHistoryRepo.Add(productHistory);
        }
        productHistory.AddPrice(product.Price);

        return new NewPriceResponse(product);
    }
}
