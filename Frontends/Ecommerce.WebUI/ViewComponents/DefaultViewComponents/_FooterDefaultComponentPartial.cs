using Ecommerce.WebUI.Services.CatalogServices.AboutService;
using ECommerce.DtoLayer.CalatogDtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FooterDefaultComponentPartial:ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _FooterDefaultComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
