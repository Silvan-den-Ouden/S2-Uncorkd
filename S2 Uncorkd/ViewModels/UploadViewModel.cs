using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class UploadViewModel
    {
        public WineryModel Winery { get; set; }
        public List<TasteTagModel> TasteTags { get; set; }

        public UploadViewModel(WineryModel _winery, List<TasteTagModel> _tasteTags)
        {
            Winery = _winery;
            TasteTags = _tasteTags;
        }
    }
}
