using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ShoppingCarViewCpmponents
{
    public class _ShoppingCartProductListComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
