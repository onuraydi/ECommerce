using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using ECommerce.DtoLayer.CalatogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductDefaultComponentPartial: ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
