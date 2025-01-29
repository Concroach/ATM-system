using Lab5.Presentation.Console.Scenarios.UserScenarios;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.SelectAction;

public class SelectSelectActionScenario : ISelectActionScenario
{
    private IScenarioProvider? _scenarioProvider;

    public string Name => "Select action";

    public void Run()
    {
        if (_scenarioProvider != null)
        {
            bool exit = false;

            while (!exit)
            {
                SelectionPrompt<IScenario> selection = new SelectionPrompt<IScenario>()
                    .Title("Select Action")
                    .AddChoices(_scenarioProvider.GetScenarios())
                    .UseConverter(x => x.Name);

                IScenario scenario = AnsiConsole.Prompt(selection);

                if (scenario is LogoutScenario)
                {
                    exit = true;
                    AnsiConsole.MarkupLine("[yellow]Confirm the exit, click logout again...[/]");
                }
                else
                {
                    AnsiConsole.Clear();
                    scenario.Run();
                }
            }
        }
    }

    public void SetScenarioProvider(IScenarioProvider scenarioProvider)
    {
        _scenarioProvider = scenarioProvider;
    }
}
