using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ReviewsViewModel
    {
        public List<ReviewModel> Reviews { get; set; }
        public List<WineModel> Wines { get; set; }
        public List<WineryModel> Wineries { get; set; }
        public List<List<TasteTagModel>> TasteTags { get; set; }
        public int PageNumber { get; set; }

        public ReviewsViewModel(List<ReviewModel> _reviews, List<WineModel> _wines, List<WineryModel> _wineries, List<List<TasteTagModel>> _tasteTags, int _pageNumber) {
            Reviews = _reviews;
            Wines = _wines;
            Wineries = _wineries;
            TasteTags = _tasteTags;
            PageNumber = _pageNumber;
        }
    }
}
