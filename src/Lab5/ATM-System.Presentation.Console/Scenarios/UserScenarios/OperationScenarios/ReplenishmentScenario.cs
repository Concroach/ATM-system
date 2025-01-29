using Lab5.Application.Contracts.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.UserScenarios.OperationScenarios;

public class ReplenishmentScenario : IScenario
{
    private readonly IUserService _userService;

    public ReplenishmentScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Replenishment account";

    public void Run()
    {
        float amount = AnsiConsole.Ask<float>("How much to deposit to the account?");
        if (amount < 0)
        {
            AnsiConsole.WriteLine("Amount cant be < 0");
            return;
        }

        UserOperationResult result = _userService.ChangeAccount(amount);

        if (result is UserOperationResult.Failure failure)
        {
            AnsiConsole.WriteLine(failure.Message);
        }

        if (result is UserOperationResult.Success)
        {
            AnsiConsole.WriteLine("success");
        }

        AnsiConsole.Ask<string>("Type b to exit");
        AnsiConsole.Clear();
    }
}