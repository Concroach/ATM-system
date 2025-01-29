using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.DataBase;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models.Users;

namespace Workshop5.Application.SyncServices.UserServices;

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

    public UserOperationResult GetBalance()
    {
        if (User is null)
            return new UserOperationResult.Failure("User is null");

        return new UserOperationResult.Money(User.Balance);
    }

    public UserOperationResult ChangeAccount(float amount)
    {
        if (User is null)
            return new UserOperationResult.Failure("User is null");

        OperationResult attempt = _userRepository.ChangeUserMoneyAsync(User, amount);
        if (attempt is OperationResult.Failure failure)
            return new UserOperationResult.Failure(failure.Message);

        if (attempt is OperationResult.Success success)
        {
            User = success.User;
            return new UserOperationResult.Success();
        }

        if (attempt is OperationResult.InsufficientFunds insufficientFunds)
            return new UserOperationResult.Failure("Not enough money");

        return new UserOperationResult.Failure("Operation is failed");
    }

    public UserOperationResult GetUserOperations()
    {
        Task<int> userId = _userRepository.GetUserByNameAsync(User?.Name);
        return new UserOperationResult.UserOperations(_operationRepository.GetAllOperations(userId));
    }
}