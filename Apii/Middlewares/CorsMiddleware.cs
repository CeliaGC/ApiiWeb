//using Microsoft.AspNetCore.Cors.Infrastructure;


//public class CorsMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly CorsPolicy _policy;

//    public CorsMiddleware(RequestDelegate next, CorsPolicy policy)
//    {
//        _next = next;
//        _policy = policy;
//    }
//    public async Task InvokeAsync(HttpContext context)
//    {
//        if (context.Request.Headers.ContainsKey("Origin"))
//        {
//            var origin = context.Request.Headers["Origin"].ToString();
//            if (_policy.IsOriginAllowed(origin))
//            {
//                context.Response.Headers.Add("Access-Control-Allow-Origin", origin);
//                context.Response.Headers.Add("Access-Control-Allow-Methods", _policy.Methods);
//                context.Response.Headers.Add("Access-Control-Allow-Headers", _policy.Headers);
//            }
//        }

//        if (context.Request.Method == "OPTIONS")
//        {
//            context.Response.StatusCode = 200;
//            return;
//        }

//        await _next(context);
//    }
//}

//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//namespace Apii
//{

//    public class CorsMiddleware
//    {
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // ...otros middlewares
//            app.Use(async (context, next) =>
//            {
//                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
//                context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
//                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
//                await next.Invoke();
//            });
//            // ...otros middlewares
//        }
//    }

//}



