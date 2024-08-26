using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using ECommerce.DtoLayer.IdentityDtos.LoginDtos;
using ECommerce.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace Ecommerce.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {//ClientSettings interface olmadığı için Ioptions geçtik ve valuesini aldık
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdinetityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });

            var RefreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            
            RefreshTokenRequest refreshTokenRequest = new()
            {
                ClientId = _clientSettings.ECommerceManagerClient.ClientId,  // manager için çalıştık diğerleri de eklenecek
                ClientSecret = _clientSettings.ECommerceManagerClient.ClientSecret,
                RefreshToken = RefreshToken,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,  // kısa süreli token ~1 saat
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,  // uzun süreli token ~30 gün
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            };
            var result = await _contextAccessor.HttpContext.AuthenticateAsync();

            var proporties = result.Properties;
            proporties.StoreTokens(authenticationToken);
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal,proporties);
            return true;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdinetityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.ECommerceManagerClient.ClientId,  // manager için çalıştık diğerleri de eklenecek
                ClientSecret = _clientSettings.ECommerceManagerClient.ClientSecret,
                UserName = signInDto.UserName,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProporties = new AuthenticationProperties();

            authenticationProporties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,  // kısa süreli token ~1 saat
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,  // uzun süreli token ~30 gün
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddMinutes(token.ExpiresIn).ToString()
                }
            });

            authenticationProporties.IsPersistent = false;


            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProporties);
            
            return true;
        }
    }
}
