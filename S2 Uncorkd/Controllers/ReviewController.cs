using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class ReviewController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        private readonly ReviewCollection _reviewCollection = new();
        private readonly TasteTagCollection _tasteTagCollection = new();

        private readonly WineRepository _wineRepository = new();
        private readonly ReviewRepository _reviewRepository = new();
        private readonly TasteTagRepository _tasteTagRepository = new();

        public IActionResult Index(int id)
        {
            WineModel wineModel = _wineCollection.GetWithID(id, _wineRepository);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll(_tasteTagRepository);


            ReviewViewModel reviewViewModel = new(wineModel, tasteTagModels);
            return View(reviewViewModel);
        }

        public IActionResult Update(int id)
        {
            ReviewModel reviewModel = _reviewCollection.GetWithID(id, _reviewRepository);
            WineModel wineModel = _wineCollection.GetWithID(reviewModel.Wine.Id, _wineRepository);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll(_tasteTagRepository);

            ReviewViewModel reviewViewModel = new(wineModel, reviewModel, tasteTagModels);
            return View(reviewViewModel);
        }

        public IActionResult SendData(int sliderValue, int wineId, string tasteTags, string comment)
        {
            _reviewCollection.Create(2, wineId, sliderValue, tasteTags, comment, _reviewRepository);

            var responseData = new { tasteTags };

            return Json(responseData);
        }

        public void UpdateReview(int sliderValue, int reviewId, string tasteTags, string comment)
        {
            _reviewCollection.Update(2, reviewId, sliderValue, tasteTags, comment, _reviewRepository);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewCollection.Delete(reviewId, _reviewRepository);
        }

    }
}
