using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using ECommerce.DtoLayer.CalatogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOfferController(IHttpClientFactory httpClientFactory, ISpecialOfferService specialOfferService)
        {
            _httpClientFactory = httpClientFactory;
            _specialOfferService = specialOfferService;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.baslik = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Listesi";

            var values = await _specialOfferService.GetAllSpeacialOfferAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.baslik = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Ekleme";
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.baslik = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Güncelleme";

            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);

        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpeacialOfferDto updateSpeacialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpeacialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

        }

        [HttpDelete("{id}")]
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpeacilOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

        }
    }
}
