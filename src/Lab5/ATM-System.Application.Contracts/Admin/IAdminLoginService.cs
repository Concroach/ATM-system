namespace Lab5.Application.Contracts.Admin;

public interface IAdminLoginService
{
    AdminLoginResult Login(string? password);
}