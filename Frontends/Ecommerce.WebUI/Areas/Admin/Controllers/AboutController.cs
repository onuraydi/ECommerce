using Ecommerce.WebUI.Services.CatalogServices.AboutService;
using ECommerce.DtoLayer.CalatogDtos.AboutDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;
        public AboutController(IHttpClientFactory httpClientFactory, IAboutService aboutService)
        {
            _httpClientFactory = httpClientFactory;
            _aboutService = aboutService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.baslik = "Hakkımda Kısmı İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda Kısmı";
            ViewBag.v3 = "Hakkımda Kısmı Listesi";

            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            ViewBag.baslik = "Hakkımda Kısmı İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda Kısmı";
            ViewBag.v3 = "Hakkımda Kısmı Ekleme";

            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.baslik = "Hakkımda Kısmı İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda Kısmı";
            ViewBag.v3 = "Hakkımda Kısmı Güncelleme";

            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
