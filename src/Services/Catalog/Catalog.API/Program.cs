namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add servies to container

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            // Configure the http request pipeline

            app.Run();
        }
    }
}
