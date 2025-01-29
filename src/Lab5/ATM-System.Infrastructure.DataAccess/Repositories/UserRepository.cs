using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.DataBase;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUserAsync(string? name, string? pinCode)
    {
        var user = new UserEntity { Name = name };
        await _dbContext.Users.AddAsync(user).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        var account = new AccountEntity { UserId = user.UserId, PinCode = pinCode, Balance = 0.0 };
        await _dbContext.Accounts.AddAsync(account).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async User? GetUserAsync(string? name, string? pinCode)
    {
        AccountEntity? account = await _dbContext.Accounts
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.User != null && a.User.Name == name && a.PinCode == pinCode).ConfigureAwait(false);

        return account == null ? null : new User(account.User?.Name, account.PinCode, account.Balance);
    }

    public async Task<int> GetUserByNameAsync(string? name)
    {
        UserEntity? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == name).ConfigureAwait(false);
        if (user == null)
        {
            throw new InvalidOperationException($"User with name '{name}' not found");
        }

        return user.UserId;
    }

    public async OperationResult ChangeUserMoneyAsync(User user, double amount)
    {
        AccountEntity? account = await _dbContext.Accounts
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.User != null && a.User.Name == user.Name && a.PinCode == user.PinCode).ConfigureAwait(false);

        if (account == null)
        {
            return new OperationResult.Failure("Account details incorrect");
        }

        if (account.Balance + amount < 0)
        {
            return new OperationResult.InsufficientFunds(new User(user.Name, user.PinCode, account.Balance));
        }

        var operation = new OperationEntity
        {
            AccountId = account.AccountId,
            AmountBefore = account.Balance,
            AmountDifference = amount,
            AmountAfter = account.Balance + amount,
        };

        account.Balance += amount;
        _dbContext.Operations.Add(operation);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return new OperationResult.Success(new User(user.Name, user.PinCode, account.Balance));
    }
}
