using Lab5.Application.Contracts.User;
using Spectre.Console;
using System.Globalization;

namespace Lab5.Presentation.Console.Scenarios.UserScenarios.OperationScenarios;

public class GetBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public GetBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Get Balance";

    public void Run()
    {
        UserOperationResult balance = _userService.GetBalance();
        if (balance is UserOperationResult.Failure failure)
        {
            AnsiConsole.WriteLine(failure.Message);
        }

        if (balance is UserOperationResult.Money money)
        {
            AnsiConsole.WriteLine(CultureInfo.InvariantCulture, money.Amount);
        }

        AnsiConsole.Ask<string>("Type b to exit");
        AnsiConsole.Clear();
    }
}