using MarketPlace.Data.Persistent.Classes;

namespace MarketPlace.Data.Persistent.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task AddAsync(Product? product);

    Task UpdateAsync(Product? product);

    Task RemoveAsync(Product? product);

    Task<List<Category>> GetAllCategoriesAsync();
}