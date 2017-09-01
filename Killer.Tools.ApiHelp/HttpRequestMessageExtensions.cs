using System.Linq;
using System.Net.Http;

namespace Killer.Tools.ApiHelp
{
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// 是不是预请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsPreRequest(this HttpRequestMessage request)
        {
            return request.Method == HttpMethod.Options &&
               request.Headers.GetValues("Origin").Any() &&
               request.Headers.GetValues("Access-Control-Request-Method").Any();
        }
    }
}
