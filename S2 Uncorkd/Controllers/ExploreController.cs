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
        private readonly TasteTagRepository _tasteTagRepository = new();

        public IActionResult Index()
        {
            List<WineModel> wineModels = _wineCollection.GetAll(_wineRepository, _wineryRepository, _tasteTagRepository);
            List<WineryModel> wineryModels = _wineryCollection.GetAll(_wineryRepository);
            List<WineModel> bestWines = _wineCollection.GetBest(_wineRepository, _wineryRepository, _tasteTagRepository);
            List<WineModel> popularWines = _wineCollection.GetPopular(_wineRepository, _wineryRepository, _tasteTagRepository);
            List<WineModel> randomWines = _wineCollection.GetRandom(_wineRepository, _wineryRepository, _tasteTagRepository);

            ExplorerViewModel explorerViewModel = new(wineModels, wineryModels, bestWines, popularWines, randomWines);

            return View(explorerViewModel);
        }
    }
}
