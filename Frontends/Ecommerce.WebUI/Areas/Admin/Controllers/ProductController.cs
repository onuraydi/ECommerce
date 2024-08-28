using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using ECommerce.DtoLayer.CalatogDtos.CategoryDtos;
using ECommerce.DtoLayer.CalatogDtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    { 
        private readonly IHttpClientFactory _httpClientFactory;  // bu önceki versiyonlarda kullanıldı şuan kullanılmıyor ama kalsın
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            ViewBag.baslik = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }


        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.baslik = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Yeni Ürün";

            var values = await _categoryService.GetAllCategoryAsync(); 

            //çnceki versiyon
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductDtoAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
            
        }

        [HttpDelete("{id}")]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductDtoAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });  // index yerine kategroiye göre ürünlere gönder
            
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.baslik = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme";

            var values = await _categoryService.GetAllCategoryAsync();

            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);

            // drop down list 
            // revize öncesi
            //var client2 = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client2.GetAsync("https://localhost:7070/api/Categories");
            //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            //List<SelectListItem> categoryValues1 = (from x in values2
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryID
            //                                       }).ToList();
            //ViewBag.CategoryValues = categoryValues1;
            //// updateing
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            //    return View(values);
            //}
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductDtoAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        
        }

        [Route("ProductListWithCategory")]
        [HttpGet]
        public async Task<IActionResult> ProductListWithCategory()
        {

            ViewBag.baslik = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
