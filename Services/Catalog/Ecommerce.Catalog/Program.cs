using Ecommerce.Catalog.Services.CategoryServices;
using Ecommerce.Catalog.Services.ProductDetailServices;
using Ecommerce.Catalog.Services.ProductImageServices;
using Ecommerce.Catalog.Services.ProductServices;
using Ecommerce.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Ninject ile aynı işi yapmıyor mu?
builder.Services.AddScoped<ICategoryService, CategoryService>();   // ICatergoryService istendiğinde ona Category Service Ver
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());  // Auto mapper için

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));   // get section içindeki ad appsetting.json içinde kullandığımız addır.

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;  // Database Settings içindeki değerlere ulaşmak için yazıldı
});

//AddTransient, AddScoped ve AddSingleton  farkları ?

// buraya kadar eklendi

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
