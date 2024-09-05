﻿using Ecommerce.WebUI.Services.CatalogServices.OfferDiscountServices;
using ECommerce.DtoLayer.CalatogDtos.OfferDiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial: ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
