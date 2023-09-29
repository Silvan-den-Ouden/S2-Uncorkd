using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;

namespace S2_Uncorkd.Controllers
{
    public class ReviewController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();

        public IActionResult Index(int id)
        {
            WineModel wineModel = _wineCollection.GetWithID(id);
            WineryModel wineryModel = _wineryCollection.GetWithID(wineModel.Winery_id);

            ReviewViewModel reviewViewModel = new(wineModel, wineryModel);
            return View(reviewViewModel);
        }
    }
}
