﻿using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponent
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
