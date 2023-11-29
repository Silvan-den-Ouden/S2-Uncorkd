using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class ExploreController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();

        private readonly WineRepository _wineRepository = new();
        private readonly WineryRepository _wineryRepository = new();

        public IActionResult Index()
        {
            List<WineModel> wineModels = _wineCollection.GetAll(_wineRepository);
            List<WineryModel> wineryModels = _wineryCollection.GetAll(_wineryRepository);
            List<WineModel> bestWines = _wineCollection.GetBest(_wineRepository);
            List<WineModel> popularWines = _wineCollection.GetPopular(_wineRepository);
            List<WineModel> randomWines = _wineCollection.GetRandom(_wineRepository);

            ExplorerViewModel explorerViewModel = new(wineModels, wineryModels, bestWines, popularWines, randomWines);

            return View(explorerViewModel);
        }
    }
}
