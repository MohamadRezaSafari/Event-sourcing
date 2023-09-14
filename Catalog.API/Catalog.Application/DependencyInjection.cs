using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Add MediatR to the Pipe line
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => 
                    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


        return services;
    }
}