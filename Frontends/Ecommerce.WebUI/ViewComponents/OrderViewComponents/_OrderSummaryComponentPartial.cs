using Ecommerce.WebUI.Services.BasketServices;
using Ecommerce.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial:ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;
        public _OrderSummaryComponentPartial(IBasketService basketService, IDiscountService discountService)
        {
            _basketService = basketService;
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productValues = await _basketService.GetBasket();
            ViewBag.ProductValues = productValues.TotalPrice;
            return View();
        }
    }
}
