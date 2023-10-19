using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;

namespace S2_Uncorkd.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ReviewCollection _reviewCollection = new();
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();
        private readonly TasteTagCollection _tasteTagCollection = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reviews(int user_id, int page)
        {
            List<ReviewModel> reviews = _reviewCollection.GetWithUserID(user_id, page);
            List<WineModel> wines = new();
            List<WineryModel> wineries = new();
            List<List<TasteTagModel>> tasteTags = new();
            foreach (ReviewModel review in reviews)
            {
                WineModel wine = _wineCollection.GetWithID(review.Wine_id);
                WineryModel winery = _wineryCollection.GetWithID(wine.Winery_id);
                List<TasteTagModel> tags = _tasteTagCollection.GetWithReviewID(review.Id);
                wines.Add(wine);
                wineries.Add(winery);
                tasteTags.Add(tags);
            }

            ReviewsViewModel reviewsViewModel = new(reviews, wines, wineries, tasteTags, page);

            return View(reviewsViewModel);
        }

        //public IActionResult Reviews(int review_id)
        //{
        //    ReviewModel review = _reviewCollection.GetWithID(review_id);
        //    WineModel wine = _wineCollection.GetWithID(review.Wine_id);
        //    WineryModel winery = _wineryCollection.GetWithID(wine.Winery_id);
        //    List<TasteTagModel> tags = _tasteTagCollection.GetWithReviewID(review.Id); 

        //    ReviewsViewModel reviewsViewModel = new(review, wine, winery, tags);

        //    return View(reviewsViewModel);
        //}
    }
}
