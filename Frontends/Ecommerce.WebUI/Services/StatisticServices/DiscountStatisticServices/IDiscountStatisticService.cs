﻿namespace Ecommerce.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public interface IDiscountStatisticService
    {
        Task<int> GetDiscountCouponCount();
    }
}
