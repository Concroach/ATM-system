using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.DataBase;
using Lab5.Application.Models.Users;
using System.Collections.Concurrent;

namespace Lab5.Tests;

public class FakeUserRepository : IUserRepository
{
    private readonly ConcurrentDictionary<string, User> _users = new();

    public void AddUser(string? name, string? pinCode)
    {
        if (_users.ContainsKey(name ?? string.Empty))
        {
            throw new InvalidOperationException("User with the same name already exists");
        }

        var user = new User(name, pinCode, 0);
        _users[name ?? string.Empty] = user;
    }

    public User? GetUser(string? name, string? pinCode)
    {
        if (name == null || !_users.TryGetValue(name, out User? user))
        {
            return null;
        }

        return user.PinCode == pinCode ? user : null;
    }

    public int GetUserByName(string? name)
    {
        if (name == null || !_users.ContainsKey(name))
        {
            throw new InvalidOperationException($"User with name '{name}' not found");
        }

        return 1;
    }

    public OperationResult ChangeUserMoney(User user, double amount)
    {
        throw new NotImplementedException();
    }

    public OperationResult ChangeUserMoney(User user, float amount)
    {
        if (!_users.TryGetValue(user.Name ?? string.Empty, out User? existingUser))
        {
            return new OperationResult.Failure("User not found");
        }

        if (amount < 0)
        {
            return new OperationResult.InsufficientFunds(existingUser);
        }

        User updatedUser = existingUser with { Balance = existingUser.Balance + amount };
        _users[existingUser.Name ?? string.Empty] = updatedUser;

        return new OperationResult.Success(updatedUser);
    }
}
