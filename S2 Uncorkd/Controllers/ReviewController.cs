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
        private readonly ReviewCollection _reviewCollection = new();
        private readonly TasteTagCollection _tasteTagCollection = new();

        public IActionResult Index(int id)
        {
            WineModel wineModel = _wineCollection.GetWithID(id);
            WineryModel wineryModel = _wineryCollection.GetWithID(wineModel.Winery_id);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll();


            ReviewViewModel reviewViewModel = new(wineModel, wineryModel, tasteTagModels);
            return View(reviewViewModel);
        }

        public IActionResult SendData(int sliderValue, int wineId, string tasteTags, string comment)
        {
            _reviewCollection.Create(2, wineId, sliderValue, tasteTags, comment);

            var responseData = new { tasteTags };

            return Json(responseData);
        }

    }
}
