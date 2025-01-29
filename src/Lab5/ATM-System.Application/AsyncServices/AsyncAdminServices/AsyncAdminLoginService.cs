using Lab5.Application.Contracts.Admin;
using Workshop5.Application.SyncServices.AdminServices;

namespace Workshop5.Application.AsyncServices.AsyncAdminServices;

public class AsyncAdminLoginService : IAdminLoginService
{
    private readonly IAdminConfig _config;

    public AsyncAdminLoginService(IAdminConfig config)
    {
        _config = config;
    }

    public Task<AdminLoginResult> LoginAsync(string password)
    {
        return Task.FromResult<AdminLoginResult>(password == _config.AdminPassword
            ? new AdminLoginResult.Success()
            : new AdminLoginResult.Failure("Wrong password"));
    }
}
