using Ecommerce.WebUI.Services.CatalogServices.ProductImageServices;
using ECommerce.DtoLayer.CalatogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDefatilImageSliderComponentPartial:ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _ProductDefatilImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values); 
        }
    }
}
