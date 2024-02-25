using FluentAssertions;
using MarketPlace.Data.Persistent;
using MarketPlace.Data.Persistent.Entities;
using MarketPlace.Data.Persistent.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MarketPlaceApp.Test.RespositoriesTests;

public class UserRepositoryTest
{
    private readonly DbContextOptions<DataContext> DbContextOptions;

    public UserRepositoryTest()
    {
        DbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
    }

    [Fact]
    public async Task LogInAsync_Return_CorrectResult()
    {
        //Arrange
        var context = new DataContext(DbContextOptions);

        context.Database.EnsureDeleted();

        var user = new User
        {
            Id = 1,
            FirstName = "firstName",
            LastName = "lastName",
            Login = "user",
            PasswordHash = Array.Empty<byte>(),
            PasswordSalt = Array.Empty<byte>(),
            Role = new Role
            {
                Id = 1,
                Name = "admin"
            },
            RoleId = 3,
            Email = "admin.@gmail.com",
            CreationDate = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
            IsActive = true
        };

        context.Users.Add(user);

        await context.SaveChangesAsync();

        var authRepository = new UserRepository(context);
        var providedLogin = "user";

        //Act
        var result = authRepository.GetUserAsync(providedLogin);

        //Assert
        var object1Json = JsonConvert.SerializeObject(user, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        var object2Json = JsonConvert.SerializeObject(result.Result, Formatting.None, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        Assert.Equal(object1Json, object2Json);
    }
}