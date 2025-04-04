using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Carter;
using FluentValidation;
using Marten;
using MediatR;
using Weasel.Core;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add servies to container
            var assembly = typeof(Program).Assembly;

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            builder.Services.AddValidatorsFromAssembly(assembly);

            builder.Services.AddMarten(opt =>
            {
                opt.Connection(builder.Configuration.GetConnectionString("Database")!);
                opt.AutoCreateSchemaObjects = AutoCreate.All;
            }).UseLightweightSessions();

            builder.Services.AddCarter();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

            var app = builder.Build();
            // Configure the http request pipeline
            app.MapCarter();
            app.UseExceptionHandler(opt => { });

            app.MapHealthChecks("/health");
            app.Run();
        }
    }
}
