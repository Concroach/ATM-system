using Lab5.Infrastructure.DataAccess.Extensions;
using Lab5.Presentation.Console.Extensions;
using Lab5.Presentation.Console.Scenarios;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Workshop5.Application.Extensions;
using Workshop5.Application.SyncServices.AdminServices;

namespace App;

public static class Program
{
    public static void Main()
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(
                connectionConfiguration =>
                {
                    connectionConfiguration.Host = "localhost";
                    connectionConfiguration.Port = 5432;
                    connectionConfiguration.Username = "postgres";
                    connectionConfiguration.Password = "root";
                    connectionConfiguration.Database = "postgres";
                    connectionConfiguration.SslMode = "Prefer";
                })
            .AddPresentationConsole();

        collection.AddSingleton<IAdminConfig>(_ => new AdminConfig
        {
            AdminPassword = "admin",
        });

        ServiceProvider provider = collection.BuildServiceProvider();

        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();
        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();

        while (true)
        {
            scenarioRunner.Run();
            AnsiConsole.Clear();
        }
    }
}