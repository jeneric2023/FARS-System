using FirearmManagement.APIs;

namespace FirearmManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IFirearmsService, FirearmsService>();
        services.AddScoped<INotificationsService, NotificationsService>();
        services.AddScoped<IServiceRequestsService, ServiceRequestsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
