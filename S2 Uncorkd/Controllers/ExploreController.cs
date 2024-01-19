using Microsoft.AspNetCore.Mvc;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class ExploreController : Controller
    {
        private readonly static WineRepository _wineRepository = new();
        private readonly static WineryRepository _wineryRepository = new();
        private readonly static TasteTagRepository _tasteTagRepository = new();

        private readonly static TasteTagCollection _tasteTagCollection = new(_tasteTagRepository);
        private readonly static WineryCollection _wineryCollection = new(_wineryRepository);
        private readonly WineCollection _wineCollection = new(_wineryCollection, _tasteTagCollection, _wineRepository);


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
