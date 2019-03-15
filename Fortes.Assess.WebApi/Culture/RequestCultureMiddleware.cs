using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Fortes.Assess.WebApi.Culture
{
    public class RequestCultureMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureKey = context.Request.Query["Culture"];
            if (!string.IsNullOrWhiteSpace(cultureKey))
            {
                var culture = new CultureInfo(cultureKey);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            await _next(context);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var cultureKey = context.Request.Query["Culture"];
            if (!string.IsNullOrWhiteSpace(cultureKey))
            {
                var culture = new CultureInfo(cultureKey);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            await _next(context);
        }
    }
}
