namespace Lab5.Application.Contracts.Admin.Registration;

public interface IUserRegistration
{
    UserRegistrationResult RegistrateUser(string? name, string? pinCode);
}