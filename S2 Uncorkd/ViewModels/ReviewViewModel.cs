using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ReviewViewModel
    {
        public WineModel Wine { get; set; }
        //public WineryModel Winery { get; set; }
        public List<TasteTagModel> TasteTags { get; set; }

        public ReviewViewModel(WineModel _wine, List<TasteTagModel> tasteTags)
        {
            Wine = _wine;
            TasteTags = tasteTags;
        }
    }
}
