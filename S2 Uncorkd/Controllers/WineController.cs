using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;

namespace S2_Uncorkd.Controllers
{
    public class WineController : Controller
    {
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();
        private readonly TasteTagCollection _tasteTagCollection = new();
        

        public IActionResult Index(int ID)
        {
            WineModel wineModel = _wineCollection.GetWineWithID(ID);
            WineryModel wineryModel = _wineryCollection.GetWineryWithID(wineModel.Winery_id);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetTagFromWineID(wineModel.Id);

            WineViewModel wineViewModel = new(wineModel, wineryModel, tasteTagModels);

            return View(wineViewModel);
        }

    }
}
