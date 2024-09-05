using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using ECommerce.DtoLayer.CalatogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);
        }
    }
}
