using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ReviewsViewModel
    {
        public ReviewModel Review { get; set; }
        public List<TasteTagModel> Tags { get; set; }
        public WineModel Wine { get; set; }
        public WineryModel Winery { get; set; }

        public ReviewsViewModel(ReviewModel _review, List<TasteTagModel> _tags, WineModel _wine, WineryModel _winery) {
            Review = _review;
            Tags = _tags;
            Wine = _wine;
            Winery = _winery;
        }

    }
}
