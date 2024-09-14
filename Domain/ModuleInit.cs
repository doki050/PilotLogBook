using Domain.UseCases.LogBooks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain;

public static class ModuleInit
{
    public static IServiceCollection AddPilotLogBookDomain(
        this IServiceCollection services
    )
    {
        return services
            .AddAutoMapper([Assembly.GetExecutingAssembly()], ServiceLifetime.Singleton)
            .AddScoped<CreateLogBook>()
            ;
    }
}
