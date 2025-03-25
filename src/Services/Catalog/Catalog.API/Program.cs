using Carter;
using Marten;
using Weasel.Core;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add servies to container
            builder.Services.AddCarter();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            builder.Services.AddMarten(opt =>
            {
                opt.Connection(builder.Configuration.GetConnectionString("Database")!);
                opt.AutoCreateSchemaObjects = AutoCreate.All;
            }).UseLightweightSessions();


            var app = builder.Build();
            // Configure the http request pipeline

            app.MapCarter();
            app.Run();
        }
    }
}
