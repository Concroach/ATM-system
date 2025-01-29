using Lab5.Application.Contracts.Admin;
using Lab5.Application.Contracts.Admin.Registration;
using Lab5.Application.Contracts.User;
using Microsoft.Extensions.DependencyInjection;
using Workshop5.Application.SyncServices.AdminServices;
using Workshop5.Application.SyncServices.AdminServices.UserRegistration;
using Workshop5.Application.SyncServices.UserServices;

namespace Workshop5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserLoginService, UserLoginService>();
        collection.AddScoped<IUserRegistration, Registrations>();
        collection.AddScoped<IAdminLoginService, AdminLoginService>();

        collection.AddScoped<UserService>();
        collection.AddScoped<IUserService>(
            p => p.GetRequiredService<UserService>());

        return collection;
    }
}