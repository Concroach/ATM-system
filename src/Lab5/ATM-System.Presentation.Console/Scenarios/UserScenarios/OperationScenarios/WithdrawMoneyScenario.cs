using Lab5.Application.Contracts.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.UserScenarios.OperationScenarios;

public class WithdrawMoneyScenario(IUserService userService) : IScenario
{
    public string Name => "Withdraw Money";

    public void Run()
    {
        float amount = AnsiConsole.Ask<float>("How much money to withdraw?");
        if (amount < 0)
        {
            AnsiConsole.WriteLine("Amount cant be < 0");
            return;
        }

        UserOperationResult result = userService.ChangeAccount(-amount);

        if (result is UserOperationResult.Failure failure)
        {
            AnsiConsole.WriteLine(failure.Message);
        }

        if (result is UserOperationResult.Success)
        {
            AnsiConsole.WriteLine("Success");
        }

        AnsiConsole.Ask<string>("Type b to exit");
        AnsiConsole.Clear();
    }
}