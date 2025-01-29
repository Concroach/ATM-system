using Lab5.Infrastructure.DataAccess.Extensions;
using Lab5.Presentation.Console.Extensions;
using Lab5.Presentation.WebAPI.Configuration;
using Npgsql;
using Workshop5.Application.Extensions;
using Workshop5.Application.SyncServices.AdminServices;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string? databaseSettings = builder.Configuration.GetSection("ConnectionStrings:Postgres").Value;
AdminSettings? adminSettings = builder.Configuration.GetSection("AdminConfig").Get<AdminSettings>();

builder.Services
    .AddApplication()
    .AddInfrastructureDataAccess(connectionConfiguration =>
    {
        var config = new NpgsqlConnectionStringBuilder(databaseSettings);
        connectionConfiguration.Host = config.Host ?? string.Empty;
        connectionConfiguration.Port = config.Port;
        connectionConfiguration.Username = config.Username ?? string.Empty;
        connectionConfiguration.Password = config.Password ?? string.Empty;
        connectionConfiguration.Database = config.Database ?? string.Empty;
        connectionConfiguration.SslMode = config.SslMode.ToString();
    })
    .AddPresentationConsole();

builder.Services.AddSingleton<IAdminConfig>(_ => new AdminConfig
{
    AdminPassword = adminSettings?.AdminPassword,
});

WebApplication app = builder.Build();
app.Run();
