using Lab5.Application.Contracts.Admin.Registration;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class UserCreateScenario : IScenario
{
    private readonly IUserRegistration _adminService;

    public UserCreateScenario(IUserRegistration adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create User";

    public void Run()
    {
        string? name = AnsiConsole.Ask<string>("Input name");
        string? pinCode = AnsiConsole.Ask<string>("Input pin code");
        UserRegistrationResult result = _adminService.RegistrateUser(name, pinCode);
        if (result is UserRegistrationResult.Failure failure)
        {
            AnsiConsole.Ask<string>(failure.Message);
            AnsiConsole.Clear();
            return;
        }

        AnsiConsole.Ask<string>("Success. Type b to exit");
        AnsiConsole.Clear();
    }
}