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
            WineModel wineModel = _wineCollection.GetWithID(ID);
       
            return View(wineModel);
        }

        public IActionResult Upload(int winery_ID)
        {
            WineryModel wineryModel = _wineryCollection.GetWithID(winery_ID);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll();

            UploadWineViewModel uploadViewModel = new(wineryModel, tasteTagModels);

            return View(uploadViewModel);
        }

        public IActionResult Update(int wine_ID)
        {
            WineModel wineModel = _wineCollection.GetWithID(wine_ID);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll();

            UpdateWineViewModel updateViewModel = new(wineModel,tasteTagModels);

            return View(updateViewModel);
        }

        public void Create(int wineryId, string name, string description, string tasteTags, string image_url)
        {
            _wineCollection.Create(wineryId, name, description, tasteTags, image_url);
        }

    }
}
