using MarketPlace.Application.Dto;
using MarketPlace.Data.Persistent.Classes;

namespace MarketPlaceApplication.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();

    Task<Product?> GetProductByIdAsync(int id);

    Task AddProductAsync(Product? product);

    Task UpdateProductAsync(Product? product);

    Task RemoveProductAsync(Product? product);

    Task<List<Category>> GetAllCategoriesAsync();
}