using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.User;
using Lab5.Application.Models.Users;

namespace Workshop5.Application.AsyncServices.AsyncUserServices;

public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _userRepository;
    private readonly UserService _userService;

    public UserLoginService(IUserRepository userRepository, UserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task<UserLoginResult> LoginAsync(string? name, string pinCode)
    {
        User? user = await _userRepository.GetUserAsync(name, pinCode);
        _userService.User = user;
        return new UserLoginResult.Success();
    }
}