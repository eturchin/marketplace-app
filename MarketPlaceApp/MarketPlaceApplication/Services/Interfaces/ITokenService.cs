using MarketPlace.Data.Persistent.Entities;

namespace MarketPlace.Application.Services.Interfaces;

public interface ITokenService
{
    bool IsTokenValid(string? key, string token);

    string GenerateToken(User user);
}