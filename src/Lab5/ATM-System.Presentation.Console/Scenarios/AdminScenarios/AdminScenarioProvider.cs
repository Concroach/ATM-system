using Lab5.Application.Contracts.Admin.Registration;
using Lab5.Presentation.Console.Scenarios.UserScenarios;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminScenarioProvider : IAdminScenarioProvider
{
    private readonly IUserRegistration _adminService;

    public AdminScenarioProvider(IUserRegistration adminService)
    {
        _adminService = adminService;
    }

    public IEnumerable<IScenario> GetScenarios()
    {
        return new List<IScenario>()
        {
            new UserCreateScenario(_adminService),
            new LogoutScenario(),
        };
    }
}