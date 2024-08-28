using Ecommerce.WebUI.Controllers;
using Ecommerce.WebUI.Handlers;
using Ecommerce.WebUI.Services.CatalogServices.AboutService;
using Ecommerce.WebUI.Services.CatalogServices.BrandServices;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.Services.CatalogServices.FeatureServices;
using Ecommerce.WebUI.Services.CatalogServices.FeatureSliderServices;
using Ecommerce.WebUI.Services.CatalogServices.OfferDiscountServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using Ecommerce.WebUI.Services.Concrete;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using ECommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/LogOut/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "ECommerceJwt";
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "ECommerceCookie";
    opt.SlidingExpiration = true;
});

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();


builder.Services.AddHttpClient<IIdentityService, IdentityService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("serviceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdinetityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//categories
builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");  

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//products
builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//special offers
builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//feature sliders
builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//feature 
builder.Services.AddHttpClient<IFeatureService, FeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//offer discount
builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//brands
builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//abouts
builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
