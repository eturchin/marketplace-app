using MarketPlace.Application.Dto;
using MarketPlace.Data.Persistent.Entities;
using MarketPlaceApplication.Models;

namespace MarketPlace.Application.Services.Interfaces;

public interface IUserService
{
    Task<Response<long>> RegisterAsync(UserDto userDto);

    Task<Response<string>> LogInAsync(LogInDto logInDto);

    Task<Response<long>> UpdatePasswordAsync(string login, string password);

    Task<User?> GetUserByIdAsync(long id);

    Task<IEnumerable<User>> GetAllUsersAsync();
}