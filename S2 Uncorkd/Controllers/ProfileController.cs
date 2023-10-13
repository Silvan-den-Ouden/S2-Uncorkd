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

        public IActionResult Reviews(int id)
        {
            ReviewModel review = _reviewCollection.GetWithID(id);
            WineModel wine = _wineCollection.GetWithID(review.Wine_id);
            WineryModel winery = _wineryCollection.GetWithID(wine.Winery_id);
            List<TasteTagModel> tags = _tasteTagCollection.GetWithReviewID(review.Id); 

            ReviewsViewModel reviewsViewModel = new(review, wine, winery, tags);

            return View(reviewsViewModel);
        }
    }
}
