using Lab5.Application.Contracts.Admin;
using Lab5.Presentation.Console.Scenarios.SelectAction;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminLoginScenario : IScenario
{
    private readonly ISelectActionScenario _scenario;
    private readonly IScenarioProvider _scenarioProvider;
    private readonly IAdminLoginService _loginService;

    public AdminLoginScenario(IAdminLoginService loginService, IScenarioProvider scenarioProvider, ISelectActionScenario scenario)
    {
        _loginService = loginService;
        _scenarioProvider = scenarioProvider;
        _scenario = scenario;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string? password = AnsiConsole.Ask<string>("Enter admin password");

        AdminLoginResult loginResult = _loginService.Login(password);
        AnsiConsole.Clear();
        if (loginResult is AdminLoginResult.Failure failure)
        {
            AnsiConsole.Ask<string>(failure.Message);
        }

        if (loginResult is AdminLoginResult.Success)
        {
            _scenario.SetScenarioProvider(_scenarioProvider);
            _scenario.Run();
        }
    }
}