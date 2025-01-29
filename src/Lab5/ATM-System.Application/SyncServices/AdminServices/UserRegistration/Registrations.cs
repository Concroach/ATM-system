using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Admin.Registration;

namespace Workshop5.Application.SyncServices.AdminServices.UserRegistration;

public class Registrations : IUserRegistration
{
    private readonly IUserRepository _userRepository;

    public Registrations(IUserRepository repository)
    {
        _userRepository = repository;
    }

    public UserRegistrationResult RegistrateUser(string? name, string? pinCode)
    {
        _userRepository.AddUserAsync(name, pinCode);
        return new UserRegistrationResult.Success();
    }
}