using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;

namespace S2_Uncorkd.Controllers
{
    public class ExploreController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();

        public IActionResult Index()
        {
            List<WineModel> wineModels = _wineCollection.GetWines();
            List<WineryModel> wineryModels = _wineryCollection.GetWineries();

            ExplorerViewModel explorerViewModel = new(wineModels, wineryModels);

            return View(explorerViewModel);
        }
    }
}
