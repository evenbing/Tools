using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;

namespace Killer.Tools.ApiHelp.KillerDelegatingHandler
{
    /// <summary>
    /// 自动实现容许跨域
    /// </summary>
    public class KillerCorsMessageHandler : DelegatingHandler
    {
        public static string Origin { get; set; }

        public KillerCorsMessageHandler()
        {

        }
        public KillerCorsMessageHandler(string origin)
        {
            Origin = origin;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            if (!IsOrigin(request))
            {
                response = request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, "Cross-origin request denied");
                return Task.FromResult(response);
            }
            if (!request.IsPreRequest())
            {
                response = base.SendAsync(request, cancellationToken).Result;
            }
            SetResponseHeaders(response, request);
            return Task.FromResult(response);
        }
        private bool IsOrigin(HttpRequestMessage requestMessage)
        {
            var origin = requestMessage.Headers.GetValues("Origin").FirstOrDefault();
            if (!string.IsNullOrEmpty(origin) && !string.IsNullOrEmpty(Origin)
            {
                return origin == Origin;
            }
            return true;
        }
        private void SetResponseHeaders(HttpResponseMessage responseMessage, HttpRequestMessage requestMessage)
        {
            var origin = requestMessage.Headers.GetValues("Origin").FirstOrDefault();
            if (string.IsNullOrEmpty(origin))
            {
                origin = "*";
            }
            responseMessage.Headers.Add("Access-Control-Allow-Origin", origin);
            if (requestMessage.IsPreRequest())
            {
                responseMessage.Headers.Add("Access-Control-Allow-Methods", "*");
                string requestHeaders = requestMessage.Headers.GetValues("Access-Control-Request-Headers").FirstOrDefault();
                if (!string.IsNullOrEmpty(requestHeaders))
                {
                    responseMessage.Headers.Add("Access-Control-Allow-Headers", requestHeaders);
                }
            }
        }
    }
}
