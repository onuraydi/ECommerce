using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using ECommerce.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Ecommerce.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync("ecommercetoken");
            if(currentToken!=null)
            {
                return currentToken.AccessToken;
            }
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdinetityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.ECommerceVisitorClient.ClientId,
                ClientSecret = _clientSettings.ECommerceVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint,
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            await _clientAccessTokenCache.SetAsync("ecommercetoken", newToken.AccessToken, newToken.ExpiresIn);
            return newToken.AccessToken;
        }
    }
}
