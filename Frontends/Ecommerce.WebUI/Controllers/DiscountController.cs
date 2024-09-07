using Ecommerce.WebUI.Services.BasketServices;
using Ecommerce.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }
        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string couponCode)
        {
            var values = await _discountService.GetDiscountCode(couponCode);
            var rateValues = await _discountService.GetDiscountCouponCouponRate(couponCode);
            var basketValues = await _basketService.GetBasket();

            var totalNewPriceWithDiscount = basketValues.TotalPrice - (basketValues.TotalPrice / 100 * rateValues);
            var totalDiscount = (basketValues.TotalPrice / 100 * rateValues);

            decimal cargo;
            decimal totalPrice = totalNewPriceWithDiscount;
            decimal totalPriceWithCargo;
            if(basketValues.TotalPrice == 0)
            {
                cargo = 0;
                totalPriceWithCargo = 0;
            }
            else if (totalPrice >= 500.00M)
            {
                cargo = 0;
                totalPriceWithCargo = totalNewPriceWithDiscount;
            }
            else
            {
                cargo = 29.99M;
                totalPriceWithCargo = totalNewPriceWithDiscount + cargo;
            }
            ViewBag.deneme = "deneme";
            ViewBag.cargoWithSale = cargo;
            ViewBag.totalWithSale = totalPriceWithCargo;
            //ViewBag.totalwithoutcargo = basketvalues.totalprice;

            return RedirectToAction("Index", "shoppingCart", new
            {
                couponCode = couponCode,
                discountRate = rateValues,
                totalWithSale = totalPriceWithCargo,
                cargoWithSale = cargo,
                totalDiscount = totalDiscount,
            });


            return View(values);
        }
    }
}
