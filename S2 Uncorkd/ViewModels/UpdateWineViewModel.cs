using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class UpdateWineViewModel
    {
        public WineModel Wine { get; set; }
        public List<TasteTagModel> TasteTags { get; set; }

        public UpdateWineViewModel(WineModel _wine, List<TasteTagModel> _tasteTags)
        {
            Wine = _wine;
            TasteTags = _tasteTags;
        }
    }
}