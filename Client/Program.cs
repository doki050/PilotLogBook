using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseRouting();
            app.UseStaticFiles();

            app.MapControllers();

            app.MapGet("/", async context =>
            {
                var filePath = "wwwroot/landing.html";
                var html = await File.ReadAllTextAsync(filePath);
                context.Response.ContentType = MediaTypeNames.Text.Html;
                await context.Response.WriteAsync(html);
            });

            app.Run();
        }
    }
}
