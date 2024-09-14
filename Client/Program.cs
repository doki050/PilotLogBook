namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            var app = builder.Build();

            // Enable routing and map the controller routes
            app.UseRouting();

            app.MapControllers(); // Use the controller we created

            app.Run();
        }
    }
}
