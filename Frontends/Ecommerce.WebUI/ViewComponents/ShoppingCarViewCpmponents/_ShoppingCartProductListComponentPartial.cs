using Ecommerce.WebUI.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ShoppingCarViewCpmponents
{
    public class _ShoppingCartProductListComponentPartial :ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
