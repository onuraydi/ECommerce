using ECommerce.Catalog.Services.StatisticServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _statisticService.GetBrandCountAsync();
            return Ok(value);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var value = await _statisticService.GetCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var value = await _statisticService.GetProductCountAsync();
            return Ok(value);
        }

        [HttpGet("GetProductAveragePrice")]
        public async Task<IActionResult> GetProductAveragePrice()
        {
            var value = await _statisticService.GetProductAvgPriceAsync();
            return Ok(value);
        }

        [HttpGet("GetMaxPricePriceProductName")]
        public async Task<IActionResult> GetMaxPricePriceProductName()
        {
            var value = await _statisticService.GetMaxPricePriceProductNameAsync();
            return Ok(value);
        }

        [HttpGet("GetMinPricePriceProductName")]
        public async Task<IActionResult> GetMinPricePriceProductName()
        {
            var value = await _statisticService.GetMinPricePriceProductNameAsync();
            return Ok(value);
        }
    }
}
