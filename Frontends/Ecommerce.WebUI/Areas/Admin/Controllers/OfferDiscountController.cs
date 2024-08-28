using Ecommerce.WebUI.Services.CatalogServices.OfferDiscountServices;
using ECommerce.DtoLayer.CalatogDtos.OfferDiscountDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDiscountService offerDiscountService)
        {
            _httpClientFactory = httpClientFactory;
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.baslik = "İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirimler";
            ViewBag.v3 = "İndirim Listesi";

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.baslik = "İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirimler";
            ViewBag.v3 = "İndirim Ekleme";
            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.baslik = "İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirimler";
            ViewBag.v3 = "İndirim Güncelleme";

            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }


        [HttpDelete("{id}")]
        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
