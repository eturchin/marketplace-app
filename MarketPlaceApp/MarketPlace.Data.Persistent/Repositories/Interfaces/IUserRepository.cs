using MarketPlace.Data.Persistent.Entities;

namespace MarketPlace.Data.Persistent.Repositories.Interfaces;

public interface IUserRepository
{
    Task RegisterAsync(User user);

    Task<User?> GetUserAsync(string login);

    Task<bool> UserExistsAsync(string login);

    Task UpdatePasswordAsync(User user);

    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User?> GetUserByIdAsync(long id);
}