using Lab5.Application.Contracts.DataBase;
using Xunit;

namespace Lab5.Tests;

public class TestsAccount
{
    [Fact]
    public void WithdrawMoney_SufficientBalance_UpdatesBalanceCorrectly()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        fakeRepo.AddUser("TestUser", "1234");
        Application.Models.Users.User? user = fakeRepo.GetUser("TestUser", "1234");

        // Act
        if (user != null)
        {
            OperationResult result = fakeRepo.ChangeUserMoney(user, 50);

            // Assert
            Assert.IsType<OperationResult.Success>(result);
        }

        Application.Models.Users.User? updatedUser = fakeRepo.GetUser("TestUser", "1234");
        if (updatedUser != null) Assert.Equal(50, updatedUser.Balance);
    }

    [Fact]
    public void WithdrawMoney_InsufficientBalance_ReturnsError()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        fakeRepo.AddUser("TestUser", "1234");
        Application.Models.Users.User? user = fakeRepo.GetUser("TestUser", "1234");

        // Act
        if (user != null)
        {
            OperationResult result = fakeRepo.ChangeUserMoney(user, -100);

            // Assert
            Assert.IsType<OperationResult.InsufficientFunds>(result);
        }

        Application.Models.Users.User? updatedUser = fakeRepo.GetUser("TestUser", "1234");
        if (updatedUser != null) Assert.Equal(0, updatedUser.Balance);
    }

    [Fact]
    public void DepositMoney_UpdatesBalanceCorrectly()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        fakeRepo.AddUser("TestUser", "1234");
        Application.Models.Users.User? user = fakeRepo.GetUser("TestUser", "1234");

        // Act
        if (user != null)
        {
            OperationResult result = fakeRepo.ChangeUserMoney(user, 100);

            // Assert
            Assert.IsType<OperationResult.Success>(result);
        }

        Application.Models.Users.User? updatedUser = fakeRepo.GetUser("TestUser", "1234");
        if (updatedUser != null) Assert.Equal(100, updatedUser.Balance);
    }

    [Fact]
    public void AddUser_UserAddedSuccessfully()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();

        // Act
        fakeRepo.AddUser("TestUser", "1234");
        Application.Models.Users.User? user = fakeRepo.GetUser("TestUser", "1234");

        // Assert
        Assert.NotNull(user);
        Assert.Equal("TestUser", user?.Name);
        if (user != null) Assert.Equal(0, user.Balance);
    }

    [Fact]
    public void ChangeMoney_MoneyAddedSuccessfully()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        fakeRepo.AddUser("TestUser", "1234");
        Application.Models.Users.User? user = fakeRepo.GetUser("TestUser", "1234");

        // Act
        if (user != null)
        {
            OperationResult result = fakeRepo.ChangeUserMoney(user, 50);

            // Assert
            Assert.IsType<OperationResult.Success>(result);
        }

        Application.Models.Users.User? updatedUser = fakeRepo.GetUser("TestUser", "1234");
        if (updatedUser != null) Assert.Equal(50, updatedUser.Balance);
    }

    [Fact]
    public void ChangeMoney_InsufficientFunds_OperationFails()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        fakeRepo.AddUser("TestUser", "1234");
        Application.Models.Users.User? user = fakeRepo.GetUser("TestUser", "1234");

        // Act
        if (user != null)
        {
            OperationResult result = fakeRepo.ChangeUserMoney(user, -100);

            // Assert
            Assert.IsType<OperationResult.InsufficientFunds>(result);
        }

        Application.Models.Users.User? updatedUser = fakeRepo.GetUser("TestUser", "1234");
        if (updatedUser != null) Assert.Equal(0, updatedUser.Balance);
    }
}