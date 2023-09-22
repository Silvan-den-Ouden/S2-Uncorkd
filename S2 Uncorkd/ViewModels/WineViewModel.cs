using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class WineViewModel
    {
        public WineModel Wine { get; set; }
        public WineryModel Winery { get; set; }
        public List<TasteTagModel> TasteTags { get; set; }

        public WineViewModel(WineModel _wine, WineryModel _winery, List<TasteTagModel> tasteTags)
        {
            Wine = _wine;
            Winery = _winery;
            TasteTags = tasteTags;
        }
    }
}
