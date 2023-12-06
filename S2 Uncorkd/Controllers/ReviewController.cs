using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class ReviewController : Controller
    {
        private readonly static ReviewRepository _reviewRepository = new();
        private readonly static WineRepository _wineRepository = new();
        private readonly static WineryRepository _wineryRepository = new();
        private readonly static TasteTagRepository _tasteTagRepository = new();

        private readonly static TasteTagCollection _tasteTagCollection = new(_tasteTagRepository);
        private readonly static WineryCollection _wineryCollection = new(_wineryRepository);
        private readonly static WineCollection _wineCollection = new(_wineryCollection, _tasteTagCollection, _wineRepository);
        private readonly ReviewCollection _reviewCollection = new(_wineCollection, _tasteTagCollection, _reviewRepository);

        private readonly int user_id = 2;

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
            List<TasteTagModel> tasteTagList = new();

            foreach (var tag in tasteTags.Split(","))
            {
                int tag_id = int.Parse(tag.Trim());
                tasteTagList.Add(_tasteTagCollection.GetWithId(tag_id));
            }

            ReviewModel reviewModel = new()
            {
                User_id = user_id,
                Wine = _wineCollection.GetWithID(wineId),
                Stars = sliderValue / 4,
                Comment = comment,
                TasteTags = tasteTagList,
            };

            _reviewCollection.Create(reviewModel);

            var responseData = new { tasteTags };

            return Json(responseData);
        }

        public void UpdateReview(int sliderValue, int reviewId, string tasteTags, string comment)
        {
            List<TasteTagModel> tasteTagList = new();

            foreach (var tag in tasteTags.Split(","))
            {
                int tag_id = int.Parse(tag.Trim());
                tasteTagList.Add(_tasteTagCollection.GetWithId(tag_id));
            }

            ReviewModel reviewModel = new()
            {
                Id = reviewId,
                //User_id = user_id,
                //Wine = _wineCollection.GetWithID(wineId),
                Stars = sliderValue,
                Comment = comment,
                TasteTags = tasteTagList,
            };

            _reviewCollection.Update(reviewModel);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewCollection.Delete(reviewId);
        }

    }
}
