using Lab5.Application.Contracts.Admin;

namespace Workshop5.Application.SyncServices.AdminServices;

public class AdminLoginService : IAdminLoginService
{
    private readonly IAdminConfig _config;

    public AdminLoginService(IAdminConfig config)
    {
        _config = config;
    }

    public AdminLoginResult Login(string? password)
    {
        if (password == _config.AdminPassword)
            return new AdminLoginResult.Success();

        return new AdminLoginResult.Failure("Wrong password");
    }
}