using Ecommerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;
using System.Net.Http.Headers;

namespace Ecommerce.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler:DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IIdentityService _identityService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor contextAccessor, IIdentityService identityService)
        {
            _contextAccessor = contextAccessor;
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",accessToken);
            var response = await base.SendAsync(request, cancellationToken);
            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var tokenResponse = await _identityService.GetRefreshToken();

                if(tokenResponse != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // hata mesajı
            }
            return response;
        }
    }
}
