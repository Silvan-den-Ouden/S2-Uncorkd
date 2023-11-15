using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;

namespace S2_Uncorkd.Controllers
{
    public class ReviewController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        private readonly ReviewCollection _reviewCollection = new();
        private readonly TasteTagCollection _tasteTagCollection = new();

        public IActionResult Index(int id)
        {
            WineModel wineModel = _wineCollection.GetWithID(id);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll();


            ReviewViewModel reviewViewModel = new(wineModel, tasteTagModels);
            return View(reviewViewModel);
        }

        public IActionResult Update(int id)
        {
            ReviewModel reviewModel = _reviewCollection.GetWithID(id);
            WineModel wineModel = _wineCollection.GetWithID(reviewModel.Wine.Id);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll();

            ReviewViewModel reviewViewModel = new(wineModel, reviewModel, tasteTagModels);
            return View(reviewViewModel);
        }

        public IActionResult SendData(int sliderValue, int wineId, string tasteTags, string comment)
        {
            _reviewCollection.Create(2, wineId, sliderValue, tasteTags, comment);

            var responseData = new { tasteTags };

            return Json(responseData);
        }

        public void UpdateReview(int sliderValue, int reviewId, string tasteTags, string comment)
        {
            _reviewCollection.Update(2, reviewId, sliderValue, tasteTags, comment);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewCollection.Delete(reviewId);
        }

    }
}
