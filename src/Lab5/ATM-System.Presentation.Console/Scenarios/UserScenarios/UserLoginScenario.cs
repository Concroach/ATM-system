using Lab5.Application.Contracts.User;
using Lab5.Presentation.Console.Scenarios.SelectAction;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.UserScenarios;

public class UserLoginScenario : IScenario
{
    private readonly IUserLoginService _loginService;
    private readonly IUserScenarioProvider _scenarioProvider;
    private readonly ISelectActionScenario _scenario;

    public UserLoginScenario(IUserLoginService loginService, ISelectActionScenario scenario, IUserScenarioProvider scenarioProvider)
    {
        _loginService = loginService;
        _scenario = scenario;
        _scenarioProvider = scenarioProvider;
    }

    public string Name => "Users Login";

    public void Run()
    {
        string? name = AnsiConsole.Ask<string>("Enter name");
        string? pinCode = AnsiConsole.Ask<string>("Enter pin code");

        UserLoginResult loginResult = _loginService.Login(name, pinCode);
        AnsiConsole.Clear();
        if (loginResult is UserLoginResult.Failure failure)
        {
            AnsiConsole.Ask<string>(failure.Message);
        }

        if (loginResult is UserLoginResult.Success)
        {
            _scenario.SetScenarioProvider(_scenarioProvider);
            _scenario.Run();
        }
    }
}