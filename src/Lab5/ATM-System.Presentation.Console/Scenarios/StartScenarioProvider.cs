using Lab5.Application.Contracts.Admin;
using Lab5.Application.Contracts.User;
using Lab5.Presentation.Console.Scenarios.AdminScenarios;
using Lab5.Presentation.Console.Scenarios.SelectAction;
using Lab5.Presentation.Console.Scenarios.UserScenarios;

namespace Lab5.Presentation.Console.Scenarios;

public class StartScenarioProvider : IStartScenarioProvider
{
    private readonly IUserLoginService _loginService;
    private readonly IUserScenarioProvider _scenarioProvider;
    private readonly ISelectActionScenario _scenario;
    private readonly IAdminScenarioProvider _adminScenarioProvider;
    private readonly IAdminLoginService _adminLoginService;

    public StartScenarioProvider(
        IUserLoginService loginService,
        IUserScenarioProvider scenarioProvider,
        ISelectActionScenario scenario,
        IAdminScenarioProvider adminScenarioProvider,
        IAdminLoginService adminLoginService)
    {
        _loginService = loginService;
        _scenarioProvider = scenarioProvider;
        _adminScenarioProvider = adminScenarioProvider;
        _adminLoginService = adminLoginService;
        _scenario = scenario;
    }

    public IEnumerable<IScenario> GetScenarios()
    {
        return new List<IScenario>
        {
            new UserLoginScenario(
                _loginService,
                _scenario,
                _scenarioProvider),
            new AdminLoginScenario(
                _adminLoginService,
                _adminScenarioProvider,
                _scenario),
        };
    }
}