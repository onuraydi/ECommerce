﻿using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPriceFilterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
