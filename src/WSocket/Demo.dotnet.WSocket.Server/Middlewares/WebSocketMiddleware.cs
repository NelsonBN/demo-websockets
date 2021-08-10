using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace Demo.WSocket.Server.Middlewares
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;

        public WebSocketMiddleware(
            RequestDelegate next
        )
        {
            this._next = next;
        }

        // Test with https://localhost:5001/Privacy/?option=Hello
        public async Task Invoke(HttpContext httpContext, WebSocketHost host)
        {
            if(httpContext.Request.Path == "/chat")
            {
                if(httpContext.WebSockets.IsWebSocketRequest)
                {
                    using(var webSocket = await httpContext.WebSockets.AcceptWebSocketAsync())
                    {
                        await host.Send(webSocket);
                    }
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
        }
    }
}