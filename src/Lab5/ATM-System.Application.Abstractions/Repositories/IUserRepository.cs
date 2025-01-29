using Lab5.Application.Contracts.DataBase;
using Lab5.Application.Models.Users;

namespace ATM;

public interface IUserRepository
{
    public Task AddUserAsync(string? name, string? pinCode);

    public User? GetUserAsync(string? name, string? pinCode);

    public Task<int> GetUserByNameAsync(string? name);

    public OperationResult ChangeUserMoneyAsync(User user, double amount);
}