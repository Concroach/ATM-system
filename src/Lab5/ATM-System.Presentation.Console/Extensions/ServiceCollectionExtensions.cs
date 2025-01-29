using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.AdminScenarios;
using Lab5.Presentation.Console.Scenarios.SelectAction;
using Lab5.Presentation.Console.Scenarios.UserScenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IStartScenarioProvider, StartScenarioProvider>();
        collection.AddScoped<IAdminScenarioProvider, AdminScenarioProvider>();
        collection.AddScoped<IUserScenarioProvider, UserScenarioProvider>();
        collection.AddScoped<ISelectActionScenario, SelectSelectActionScenario>();

        return collection;
    }
}