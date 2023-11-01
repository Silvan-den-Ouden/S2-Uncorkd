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
            List<WineModel> wineModels = _wineCollection.GetAll();
            List<WineryModel> wineryModels = _wineryCollection.GetAll();
            List<WineModel> bestWines = _wineCollection.GetBest();
            List<WineModel> popularWines = _wineCollection.GetPopular();
            List<WineModel> randomWines = _wineCollection.GetRandom();

            ExplorerViewModel explorerViewModel = new(wineModels, wineryModels, bestWines, popularWines, randomWines);

            return View(explorerViewModel);
        }
    }
}
