﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;

namespace S2_Uncorkd.Controllers
{
    public class WineController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        public IActionResult Index()
        {
            List<WineModel> wineModels = _wineCollection.GetWines();

            return View(wineModels);
        }


    }
}
