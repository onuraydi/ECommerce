using Ecommerce.WebUI.Controllers;
using Ecommerce.WebUI.Handlers;
using Ecommerce.WebUI.Services.BasketServices;
using Ecommerce.WebUI.Services.CargoServices.CargoCompanyServices;
using Ecommerce.WebUI.Services.CargoServices.CargoCustomerServices;
using Ecommerce.WebUI.Services.CatalogServices.AboutService;
using Ecommerce.WebUI.Services.CatalogServices.BrandServices;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.Services.CatalogServices.ContactServices;
using Ecommerce.WebUI.Services.CatalogServices.FeatureServices;
using Ecommerce.WebUI.Services.CatalogServices.FeatureSliderServices;
using Ecommerce.WebUI.Services.CatalogServices.OfferDiscountServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductDetailServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductImageServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using Ecommerce.WebUI.Services.CommentServices;
using Ecommerce.WebUI.Services.Concrete;
using Ecommerce.WebUI.Services.DiscountServices;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.OrderServices.OrderAddressServices;
using Ecommerce.WebUI.Services.OrderServices.OrderOrderingServices;
using Ecommerce.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Ecommerce.WebUI.Services.StatisticServices.DiscountStatisticServices;
using Ecommerce.WebUI.Services.StatisticServices.MessageStatisticService;
using Ecommerce.WebUI.Services.StatisticServices.MessageStatisticServices;
using Ecommerce.WebUI.Services.StatisticServices.UserStatisticServices;
using Ecommerce.WebUI.Services.UserIdentityServices;
using Ecommerce.WebUI.Services.UserMessageServices;
using Ecommerce.WebUI.Settings;
using ECommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Razor;

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

//Product images
builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//Product details
builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
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

//comments
builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//contact
builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

//Basket
builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");

}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();  // dikkat birkaç tanesi de bu şekilde olabilir

//Discount coupon
builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");

}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();  // dikkat birkaç tanesi de bu şekilde olabilir

// Order Address
builder.Services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");

}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// Order Orderings
builder.Services.AddHttpClient<IOrderOrderingService, OrderOrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// Message
builder.Services.AddHttpClient<IUserMessageService, UserMessageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// identity userList
builder.Services.AddHttpClient<IUserIdentityService, UserIdentityService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdinetityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// Cargo COmpany
builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// Cargo Customer
builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// catalog statistic
builder.Services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// user statistic
builder.Services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdinetityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();  //farklı

// Message Statistic
builder.Services.AddHttpClient<IMessageStatisticService, MessageStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

// discount Statistic
builder.Services.AddHttpClient<IDiscountStatisticService, DiscountStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();



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

var supportedCultures = new[]
{
    "en","de","tr"
};

var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture("tr").AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

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
