using System.Security.Cryptography;
using System.Text;

using FluentAssertions;

using MarketPlace.Application.Dto;
using MarketPlace.Application.Services.Implementations;
using MarketPlace.Data.Persistent.Entities;

using Moq;


using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MarketPlaceApp.Test.ServicesTests;

public class TokenServiceTest
{
    [Fact]
    public void GenerateToken_Return_NotNull()
    {
        //Arrange
        var mockConfiguration = new Mock<IConfiguration>();

        var hmac = new HMACSHA512();
        var userDto = new UserDto()
        {
            Login = "user",
            Password = "password"
        };

        var user = new User
        {
            Id = 1,
            Login = "user",
            PasswordSalt = hmac.Key,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
            Role = new Role
            {
                Id = 1,
                Name = "admin"
            }
        };

        mockConfiguration.Setup(conf => conf.GetSection("AppSettings:Token").Value)
            .Returns("MySuperSecretKey");

        var service = new TokenService(mockConfiguration.Object);

        //Act
        var result = service.GenerateToken(user);

        //Assert
        result.Should().NotBeNull();

        mockConfiguration.Verify(mock => mock.GetSection(It.IsAny<string>()), Times.Once());
    }
}