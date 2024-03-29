﻿using System.Diagnostics;

using DFC.App.ExploreCareers.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace DFC.App.ExploreCareers.Controllers
{
    public class HomeController : Controller
    {
        public const string ThisViewCanonicalName = "home";

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
