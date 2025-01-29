using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.DataBase;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models.Users;

namespace Workshop5.Application.AsyncServices.AsyncUserServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IOperationRepository _operationRepository;

    public UserService(IUserRepository userRepository, IOperationRepository operationRepository)
    {
        _userRepository = userRepository;
        _operationRepository = operationRepository;
    }

    public User? User { get; set; }

    public Task<UserOperationResult> GetBalanceAsync()
    {
        return Task.FromResult<UserOperationResult>(User is null
            ? new UserOperationResult.Failure("User is null")
            : new UserOperationResult.Money(User.Balance));
    }

    public async Task<UserOperationResult> ChangeAccountAsync(float amount)
    {
        if (User is null)
        {
            return new UserOperationResult.Failure("User is null");
        }

        OperationResult attempt = await _userRepository.ChangeUserMoneyAsync(User, amount);
        return attempt switch
        {
            OperationResult.Failure failure => new UserOperationResult.Failure(failure.Message),
            OperationResult.Success success => new UserOperationResult.Success { User = User = success.User },
            OperationResult.InsufficientFunds => new UserOperationResult.Failure("Not enough money"),
            _ => new UserOperationResult.Failure("Operation failed"),
        };
    }

    public async Task<UserOperationResult> GetUserOperationsAsync()
    {
        if (User is null)
        {
            return new UserOperationResult.Failure("User is null");
        }

        int userId = await _userRepository.GetUserByNameAsync(User.Name).ConfigureAwait(false);
        var operations = await _operationRepository.GetAllOperationsAsync(userId);
        return new UserOperationResult.UserOperations(operations);
    }
}
