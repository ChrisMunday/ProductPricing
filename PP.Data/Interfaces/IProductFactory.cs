using PP.Data.Models.Responses;

namespace PP.Data.Interfaces;

public interface IProductFactory
{
    ProductListResponse GetProducts();

    DiscountResponse ApplyDiscount(int id, decimal discountPercentage);

    NewPriceResponse UpdatePrice(int id, decimal newPrice);
}
