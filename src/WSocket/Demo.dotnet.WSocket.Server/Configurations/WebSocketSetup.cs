using Demo.WSocket.Server.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.WSocket.Server.Configurations
{
    public static class WebSocketSetup
    {
        public static IServiceCollection AddWebSocketSetup(this IServiceCollection services)
        {
            services.AddScoped<WebSocketHost>();

            return services;
        }

        public static IApplicationBuilder UseWebSocketSetup(this IApplicationBuilder app)
        {
            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(300)
            });

            app.UseMiddleware<WebSocketMiddleware>();

            return app;
        }
    }
}