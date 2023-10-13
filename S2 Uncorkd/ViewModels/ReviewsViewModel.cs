using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ReviewsViewModel
    {
        public ReviewModel Review { get; set; }
        public WineModel Wine { get; set; }
        public WineryModel Winery { get; set; }
        public List<TasteTagModel> Tags { get; set; }


        public ReviewsViewModel(ReviewModel _review, WineModel _wine, WineryModel _winery, List<TasteTagModel> _tags) {
            Review = _review;
            Wine = _wine;
            Winery = _winery;
            Tags = _tags;
        }
    }
}
