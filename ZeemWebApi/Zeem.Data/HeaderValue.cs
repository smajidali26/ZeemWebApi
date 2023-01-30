using Microsoft.AspNetCore.Http;
using Zeem.Core;
using Zeem.Core.Domain;

namespace Zeem.Data
{
    public class HeaderValue : IHeaderValue
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HeaderValue(IHttpContextAccessor httpContextAccessor) { 
            _httpContextAccessor= httpContextAccessor;
        }
        public ZeemUser CurrentUser { get => (ZeemUser)_httpContextAccessor.HttpContext.Items["User"]; }
    }
}
