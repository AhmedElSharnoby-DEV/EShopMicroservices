using Catalog.API.Common.Abstractions;

namespace Catalog.API.Extension
{
    public static class WebApplicationExtension
    {
        // register all minimal api
        public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IEndPoint> endpoints = app.Services
                .GetRequiredService<IEnumerable<IEndPoint>>();

            IEndpointRouteBuilder builder =
                routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (IEndPoint endpoint in endpoints)
            {
                endpoint.MapEndPoint(builder);
            }

            return app;
        }
    }
}
