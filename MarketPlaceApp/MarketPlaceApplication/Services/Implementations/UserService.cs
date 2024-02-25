using AutoMapper;
using MarketPlace.Application.Dto;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Data.Persistent.Entities;
using MarketPlace.Data.Persistent.Repositories.Interfaces;
using MarketPlaceApplication.Models;
using System.Security.Cryptography;
using System.Text;

namespace MarketPlace.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly ITokenService _tokenService;

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<Response<string>> LogInAsync(LogInDto logInDto)
    {
        var response = new Response<string>();
        var user = await _userRepository.GetUserAsync(logInDto.Login);

        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found";
        }
        else if (!VerifyPassword(logInDto.Password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password";
        }
        else
        {
            response.Success = true;
            response.Message = "Got token";
            response.Data = _tokenService.GenerateToken(user);
        }

        return response;
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<Response<long>> RegisterAsync(UserDto userDto)
    {
        var response = new Response<long>();
        CreatePasswordHash(userDto.Password, out var passwordHash, out var passwordSalt);

        if (await UserExistsAsync(userDto.Login))
        {
            response.Success = false;
            response.Message = "User already exists";
            return response;
        }

        var user = _mapper.Map<User>(userDto);

        user.RoleId = 2;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;
        user.CreationDate = DateTime.UtcNow;
        user.LastModified = DateTime.UtcNow;

        await _userRepository.RegisterAsync(user);

        response.Data = user.Id;
        response.Success = true;
        response.Message = "User successfully registered";
        return response;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<Response<long>> UpdatePasswordAsync(string login, string password)
    {
        var response = new Response<long>();
        var user = await _userRepository.GetUserAsync(login);
        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found";
            return response;
        }

        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.LastModified = DateTime.UtcNow;

        await _userRepository.UpdatePasswordAsync(user);
        response.Success = true;
        response.Message = "User password successfully updated";

        return response;
    }

    private async Task<bool> UserExistsAsync(string login)
    {
        return await _userRepository.UserExistsAsync(login);
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

   
}