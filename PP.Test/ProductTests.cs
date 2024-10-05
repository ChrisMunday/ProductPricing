using Moq;
using PP.Data.Factories;

namespace PP.Test;

/*
 I had considered using Mock/Setup. However as the repository data is mocked this was deemed not nesseccary.
*/

public class ProductTests
{
    private ProductFactory _factory;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _factory = new ProductFactory();
    }

    [Test]
    public void GetProducts()
    {
        // Act
        var products = _factory.GetProducts();

        // Assert
        Assert.That(products, Has.Count.GreaterThanOrEqualTo(2));
    }

    [Test]
    public void GetProductPriceHistory()
    {
        // Act
        var product = _factory.GetProductHistory(1);
        var priceHistory = product?.PriceHistory;

        // Assert
        Assert.Multiple(() => {
            Assert.That(product?.Id, Is.EqualTo(1));
            Assert.That(product?.Name, Is.EqualTo("Product A"));
            Assert.That(priceHistory?.Count(), Is.GreaterThanOrEqualTo(3));
        });
    }

    [Test]
    public void ApplyDiscount()
    {
        // Act
        var discount = _factory.ApplyDiscount(1, 10M);
        var productHistory = _factory.GetProductHistory(1);

        // Assert
        Assert.Multiple(() => {
            Assert.That(discount.Id, Is.EqualTo(1));
            Assert.That(discount.Name, Is.EqualTo("Product A"));
            Assert.That(discount.DiscountedPrice, Is.EqualTo(90M));
            Assert.That(discount.OriginalPrice, Is.EqualTo(100M));
            Assert.That(productHistory?.PriceHistory?.Count(), Is.GreaterThan(3));
            Assert.That(productHistory?.PriceHistory.First().Price, Is.EqualTo(90M));
        });
    }

    [Test]
    public void ApplyDiscountToUndiscountedProduct()
    {
        // Act
        var discount = _factory.ApplyDiscount(2, 15M);
        var productHistory = _factory.GetProductHistory(2);

        // Assert
        Assert.Multiple(() => {
            Assert.That(discount.Id, Is.EqualTo(2));
            Assert.That(discount.Name, Is.EqualTo("Product B"));
            Assert.That(discount.DiscountedPrice, Is.EqualTo(170M));
            Assert.That(discount.OriginalPrice, Is.EqualTo(200M));
            Assert.That(productHistory?.PriceHistory?.Count(), Is.Not.EqualTo(0));
            Assert.That(productHistory?.PriceHistory.First().Price, Is.EqualTo(170M));
        });
    }

    [Test]
    public void UpdateProductPrice()
    {
        // Act
        var factory = _factory.UpdatePrice(1, 150M);
        var productHistory = _factory.GetProductHistory(1);

        // Assert
        Assert.Multiple(() => {
            Assert.That(factory.Id, Is.EqualTo(1));
            Assert.That(factory.Name, Is.EqualTo("Product A"));
            Assert.That(factory.NewPrice, Is.EqualTo(150M));
            Assert.That(productHistory?.PriceHistory.First().Price, Is.EqualTo(150M));
        });
    }

    [Test]
    public void UpdateAnotherProductPrice()
    {
        // Act
        var factory = _factory.UpdatePrice(2, 300M);
        var productHistory = _factory.GetProductHistory(2);

        // Assert
        Assert.Multiple(() => {
            Assert.That(factory.Id, Is.EqualTo(2));
            Assert.That(factory.Name, Is.EqualTo("Product B"));
            Assert.That(factory.NewPrice, Is.EqualTo(300M));
            Assert.That(productHistory?.PriceHistory.First().Price, Is.EqualTo(300M));
        });
    }
}
