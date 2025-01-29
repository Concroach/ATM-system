using Lab5.Application.Contracts.User;
using Lab5.Presentation.Console.Scenarios.UserScenarios.OperationScenarios;

namespace Lab5.Presentation.Console.Scenarios.UserScenarios;

public class UserScenarioProvider : IUserScenarioProvider
{
    private readonly IUserService _userService;

    public UserScenarioProvider(IUserService userService)
    {
        _userService = userService;
    }

    public IEnumerable<IScenario> GetScenarios()
    {
        return new List<IScenario>
        {
            new ReplenishmentScenario(_userService),
            new WithdrawMoneyScenario(_userService),
            new GetBalanceScenario(_userService),
            new GetOperationsTableScenario(_userService),
            new LogoutScenario(),
        };
    }
}