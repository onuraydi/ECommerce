using Ecommerce.WebUI.Services.CommentServices;
using Ecommerce.WebUI.Services.StatisticServices.CatalogStatisticServices;
using Ecommerce.WebUI.Services.StatisticServices.DiscountStatisticServices;
using Ecommerce.WebUI.Services.StatisticServices.MessageStatisticService;
using Ecommerce.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _messageStatisticService = messageStatisticService;
            _discountStatisticService = discountStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var brandValue = await _catalogStatisticService.GetBrandCountAsync();
            ViewBag.brandValue = brandValue;

            var categoryValue = await _catalogStatisticService.GetCategoryCountAsync();
            ViewBag.categoryValue = categoryValue;

            var productValue = await _catalogStatisticService.GetProductCountAsync();
            ViewBag.productValue = productValue;

            var maxPriceValue = await _catalogStatisticService.GetMaxPriceProductNameAsync();
            ViewBag.maxPriceProductName = maxPriceValue;

            var minPriceValue = await _catalogStatisticService.GetMinPriceProductNameAsync();
            ViewBag.minPriceProductName = minPriceValue;

            //var avgPriceValue = (maxPriceValue + minPriceValue);
            //ViewBag.avgPriceProductName = avgPriceValue;

            var userValue = await _userStatisticService.GetUserCount();
            ViewBag.userValue = userValue;

            var activeCommentValue = await _commentService.GetActiveCommentCountAsync();
            ViewBag.activeCommentValue = activeCommentValue;

            var passiveCommentValue = await _commentService.GetPassiveCommentCountAsync();
            ViewBag.passiveCommentValue = passiveCommentValue;

            var TotalCommentValue = await _commentService.GetTotalCommentCountAsync();
            ViewBag.TotalCommentValue = TotalCommentValue;

            var MessageValue = await _messageStatisticService.GetTotalMessageCountAsync();
            ViewBag.MessageValue = MessageValue;

            var discountValue = await _discountStatisticService.GetDiscountCouponCount();
            ViewBag.discountCouponCount = discountValue;

            return View();
        }
    }
}
