using Lab5.Application.Contracts.User;
using Lab5.Application.Models.Operations;
using Spectre.Console;
using System.Globalization;

namespace Lab5.Presentation.Console.Scenarios.UserScenarios.OperationScenarios;

public class GetOperationsTableScenario : IScenario
{
    private readonly IUserService _userService;

    public GetOperationsTableScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Get Operations Table";

    public void Run()
    {
        UserOperationResult result = _userService.GetUserOperations();
        if (result is UserOperationResult.Failure failure)
        {
            AnsiConsole.Ask<string>(failure.Message);
        }

        if (result is UserOperationResult.UserOperations operations)
        {
            var table = new Table();
            table.AddColumn("OperationId");
            table.AddColumn("Amount Before");
            table.AddColumn("Difference");
            table.AddColumn("Amount After");

            foreach (Operation operation in operations.Operations)
            {
                table.AddRow(
                    Convert.ToString(operation.OperationId, CultureInfo.InvariantCulture),
                    Convert.ToString(operation.AmountBefore, CultureInfo.InvariantCulture),
                    Convert.ToString(operation.Difference, CultureInfo.InvariantCulture),
                    Convert.ToString(operation.AmountAfter, CultureInfo.InvariantCulture));
            }

            AnsiConsole.Write(table);
            AnsiConsole.Ask<string>("Type b to exit");
        }

        AnsiConsole.Clear();
    }
}