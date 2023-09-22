using Uncorkd_BLL.Models;

namespace S2_Uncorkd.ViewModels
{
    public class ExplorerViewModel
    {
        public List<WineModel> Wines { get; set; }
        public List<WineryModel> Wineries { get; set; }

        public ExplorerViewModel(List<WineModel> _wines, List<WineryModel> _wineries) { 
            Wines = _wines;
            Wineries = _wineries;
        }
    }
}
