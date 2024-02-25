using MarketPlace.Data.Persistent.Classes;
using MarketPlace.Data.Persistent.Entities;
using MarketPlace.Data.Persistent.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Data.Persistent.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.Include(p => p.Role).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        return await _context.Users.Include(p => p!.Role).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User?> GetUserAsync(string login)
    {
        var user = await _context.Users
            .Include(r => r.Role)
            .FirstOrDefaultAsync(u => u.Login.ToLower().Equals(login.ToLower()));
        return user;
    }

    public async Task RegisterAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UserExistsAsync(string login)
    {
        if (await _context.Users.AnyAsync(u => u.Login.ToLower().Equals(login.ToLower())))
        {
            return true;
        }

        return false;
    }

    public async Task UpdatePasswordAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}