﻿using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.ViewComponents.Widgets
{
    public class Line2 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
