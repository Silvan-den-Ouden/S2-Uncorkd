using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ReviewViewModel
    {
        public WineModel Wine { get; set; }
        public ReviewModel Review { get; set; }
        public List<TasteTagModel> TasteTags { get; set; }

        public ReviewViewModel(WineModel _wine, List<TasteTagModel> _tasteTags)
        {
            Wine = _wine;
            Review = new();
            TasteTags = _tasteTags;
        }

        public ReviewViewModel(WineModel _wine, ReviewModel _review, List<TasteTagModel> _tastetags) {
            Wine = _wine;
            Review = _review;
            TasteTags = _tastetags;
        }
    }
}
