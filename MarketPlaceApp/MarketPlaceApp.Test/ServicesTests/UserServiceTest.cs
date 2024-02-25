using System.Security.Cryptography;
using System.Text;

using AutoMapper;

using FluentAssertions;

using MarketPlace.Application.Dto;
using MarketPlace.Application.Services.Implementations;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Data.Persistent.Entities;
using MarketPlace.Data.Persistent.Repositories.Interfaces;

using Moq;

namespace MarketPlaceApp.Test.ServicesTests;

public class UserServiceTest
{
    [Fact]
    public async Task RegisterAsync_Return_Success_True()
    {
        //Arrange
        var mockService = new Mock<ITokenService>();
        var mockRepository = new Mock<IUserRepository>();
        var mockAutoMapper = new Mock<IMapper>();

        var userDto = new UserDto
        {
            Login = "user",
            Password = "password"
        };

        var user = new User
        {
            Login = "user",
        };

        mockRepository.Setup(repo => repo.RegisterAsync(user));
        mockRepository.Setup(repo => repo.UserExistsAsync(user.Login)).ReturnsAsync(false);
        mockAutoMapper
            .Setup(x => x.Map<User>(It.IsAny<UserDto>()))
            .Returns(user);

        var service = new UserService(mockRepository.Object, mockAutoMapper.Object, mockService.Object);

        //Act
        var result = await service.RegisterAsync(userDto);

        //Assert
        result.Should().NotBeNull();
        result.Success.Should().Be(true);

        mockRepository.Verify(mock => mock.RegisterAsync(It.IsAny<User>()), Times.Once());
        mockRepository.Verify(mock => mock.UserExistsAsync(It.IsAny<string>()), Times.Once());
        mockAutoMapper.Verify(mock => mock.Map<User>(It.IsAny<UserDto>()), Times.Once());
    }

    [Fact]
    public async Task LohInAsync_Return_Success_True()
    {
        //Arrange
        var mockService = new Mock<ITokenService>();
        var mockRepository = new Mock<IUserRepository>();
        var mockAutoMapper = new Mock<IMapper>();

        var hmac = new HMACSHA512();
        var logInDto = new LogInDto()
        {
            Login = "user",
            Password = "password"
        };

        var user = new User
        {
            Id = 1,
            Login = "user",
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logInDto.Password)),
            Role = new Role
            {
                Id = 1,
                Name = "admin"
            }
        };
       
        mockRepository.Setup(repo => repo.GetUserAsync(logInDto.Login)).ReturnsAsync(user);
        mockService.Setup(serv => serv.GenerateToken(It.IsAny<User>()))
            .Returns("MySuperSecretToken");

        var service = new UserService(mockRepository.Object, mockAutoMapper.Object, mockService.Object);

        //Act
        var result = await service.LogInAsync(logInDto);

        //Assert
        result.Should().NotBeNull();
        result.Success.Should().Be(true);

        mockRepository.Verify(mock => mock.GetUserAsync(It.IsAny<string>()), Times.Once());
    }

    [Fact]
    public async Task GetAllUsersAsync_Return_Success_True()
    {
        //Arrange
        var mockService = new Mock<ITokenService>();
        var mockRepository = new Mock<IUserRepository>();
        var mockAutoMapper = new Mock<IMapper>();

        var hmac = new HMACSHA512();
        var password = "password";

        var userOne = new User
        {
            Id = 1,
            Login = "userOne",
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            Role = new Role
            {
                Id = 1,
                Name = "admin"
            }
        };

        var userTwo = new User
        {
            Id = 2,
            Login = "userTwo",
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            Role = new Role
            {
                Id = 2,
                Name = "customer"
            }
        };

        var userThree = new User
        {
            Id = 3,
            Login = "userThree",
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            Role = new Role
            {
                Id = 2,
                Name = "customer"
            }
        };

        var users = new List<User>
        {
            userOne, 
            userTwo, 
            userThree
        };

        mockRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);

        var service = new UserService(mockRepository.Object, mockAutoMapper.Object, mockService.Object);

        //Act
        var result = await service.GetAllUsersAsync();

        //Assert
        result.Should().NotBeNull();

        mockRepository.Verify(mock => mock.GetAllUsersAsync(), Times.Once());
    }
}