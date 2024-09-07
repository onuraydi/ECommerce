using Ecommerce.WebUI.Services.BasketServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.Services.DiscountServices;
using ECommerce.DtoLayer.BasketDtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string couponCode, int discountRate,decimal totalWithSale, decimal cargoWithSale, decimal totalDiscount)
        {
            ViewBag.couponCode = couponCode;
            ViewBag.discountRate = discountRate;
            ViewBag.totalWithSale = totalWithSale;
            ViewBag.cargoWithSale = cargoWithSale;
            ViewBag.totalDiscount = totalDiscount;
            var values = await _basketService.GetBasket();
            decimal cargo;
            decimal totalPrice;
            if (values.TotalPrice == 0)
            {
                cargo = 0;
                totalPrice = 0;
            }
            else if (values.TotalPrice >= 500.00M)
            {
                cargo = 0;
                totalPrice = values.TotalPrice;
            }
            else
            {
                cargo = 29.99M;
                totalPrice = values.TotalPrice + cargo;
            }
            ViewBag.cargo = cargo;
            ViewBag.total = totalPrice;
            ViewBag.totalWithoutCargo = values.TotalPrice;
            return View();
        }
        
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto()
            {
                ProductId = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                ProductImageUrl = values.ProductImageURL,
                Quantity = 1 // şimdilik sabit
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
