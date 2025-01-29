using Lab5.Presentation.Console.Scenarios.SelectAction;

namespace Lab5.Presentation.Console.Scenarios;

public class ScenarioRunner
{
    private readonly IStartScenarioProvider _scenarioProvider;
    private readonly ISelectActionScenario _scenario;

    public ScenarioRunner(IStartScenarioProvider scenarioProvider, ISelectActionScenario scenario)
    {
        _scenarioProvider = scenarioProvider;
        _scenario = scenario;
    }

    public void Run()
    {
        _scenario.SetScenarioProvider(_scenarioProvider);
        _scenario.Run();
    }
}