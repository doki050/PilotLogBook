using WebApi.Configuration;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Register services using extension methods
        builder.Services.ConfigureServices(configuration);
        builder.Services.ConfigureControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the middleware pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAllOrigins");
        app.UseAuthentication();  // Make sure authentication is included
        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}