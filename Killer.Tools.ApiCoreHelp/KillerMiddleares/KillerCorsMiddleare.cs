using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Killer.Tools.ApiCoreHelp.KillerMiddleares
{
    /// <summary>
    /// core 通用组件 自定义  
    /// 为啥这样定义：参考源码
    /// https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNetCore.Http.Abstractions/Extensions/UseMiddlewareExtensions.cs
    /// </summary>
    public class KillerCorsMiddleare
    {
        public RequestDelegate Next { get; set; }
        public KillerCorsMiddleare(RequestDelegate next)
        {
            this.Next = next;
        }
        public async Task Invoke(HttpContext context, ILoggerFactory loggerFactory)
        {
            await Task.Run(() =>
            {
                if (context.Request.IsIsPreRequest())
                {
                    context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                    StringValues head;
                    if (context.Request.Headers.TryGetValue("Access-Control-Request-Headers", out head))
                    {
                        context.Response.Headers.Add("Access-Control-Request-Headers", head);
                    }
                }
                StringValues origin;
                if (context.Request.Headers.TryGetValue("Origin", out origin))
                {
                    context.Response.Headers.Add("Origin", origin);
                }
            });
        }
    }
}
