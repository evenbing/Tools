using Microsoft.AspNetCore.Http;

namespace Killer.Tools.ApiCoreHelp
{
    public static class HttpRequestExtention
    {
        public static bool IsIsPreRequest(this HttpRequest request)
        {
            return request.Method?.ToLowerInvariant() == "options" && request.Headers.Keys.Contains("Origin") && request.Headers.ContainsKey("Access-Control-Request-Method");
        }
    }
}
