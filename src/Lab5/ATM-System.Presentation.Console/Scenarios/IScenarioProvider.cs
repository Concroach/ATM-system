namespace Lab5.Presentation.Console.Scenarios;

public interface IScenarioProvider
{
    IEnumerable<IScenario> GetScenarios();
}