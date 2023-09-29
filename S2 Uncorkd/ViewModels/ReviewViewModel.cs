using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ReviewViewModel
    {
        public WineModel WineModel { get; set; }
        public WineryModel WineryModel { get; set; }

        public ReviewViewModel(WineModel _wineModel, WineryModel _wineryModel)
        {
            WineModel = _wineModel;
            WineryModel = _wineryModel;
        }
    }
}
