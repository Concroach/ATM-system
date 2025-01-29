using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models.Users;

namespace Workshop5.Application.SyncServices.UserServices;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _userRepository;
    private readonly UserService _userService;

    public UserLoginService(IUserRepository userRepository, UserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public UserLoginResult Login(string? name, string? pinCode)
    {
        User? user = _userRepository.GetUserAsync(name, pinCode);
        _userService.User = user;
        return new UserLoginResult.Success();
    }
}