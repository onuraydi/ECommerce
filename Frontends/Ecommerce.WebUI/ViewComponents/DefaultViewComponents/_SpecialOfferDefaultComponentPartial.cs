using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using ECommerce.DtoLayer.CalatogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial:ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpeacialOfferAsync();
            return View(values);
        }
    }
}
