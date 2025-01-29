using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Admin.Registration;

namespace Workshop5.Application.AsyncServices.AsyncAdminServices;

public class AsyncRegistration : IUserRegistration
{
    private readonly IUserRepository _userRepository;

    public AsyncRegistration(IUserRepository repository)
    {
        _userRepository = repository;
    }

    public async Task<UserRegistrationResult> RegistrateUserAsync(string? name, string pinCode)
    {
        await _userRepository.AddUserAsync(name, pinCode).ConfigureAwait(false);
        return new UserRegistrationResult.Success();
    }
}
