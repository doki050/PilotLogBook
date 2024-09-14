using Domain.UseCases.LogBooks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;

namespace Domain;

public static class ModuleInit
{
    public static IServiceCollection AddPilotLogBookDomain(
        this IServiceCollection services,
        IConfigurationSection domainSettings
    )
    {
        return services
            .AddAutoMapper([Assembly.GetExecutingAssembly()], ServiceLifetime.Singleton)
            .AddScoped<CreateLogBook>()
            ;
    }
}
