using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class WineController : Controller
    {
        private readonly static WineRepository _wineRepository = new();
        private readonly static WineryRepository _wineryRepository = new();
        private readonly static TasteTagRepository _tasteTagRepository = new();

        private readonly static TasteTagCollection _tasteTagCollection = new(_tasteTagRepository);
        private readonly static WineryCollection _wineryCollection = new(_wineryRepository);
        private readonly static WineCollection _wineCollection = new(_wineryCollection, _tasteTagCollection, _wineRepository);

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

            // TIMO feedback:
            if (wineModel == null)
            {
                return NotFound();
            }

            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll();

            UpdateWineViewModel updateViewModel = new(wineModel,tasteTagModels);

            return View(updateViewModel);
        }

        public void CreateWine(int wineryId, string name, string description, string tasteTags, string image_url)
        {
            _wineCollection.Create(wineryId, name, description, tasteTags, image_url);
        }

        public void UpdateWine(int wineId, string name, string description, string tasteTags, string image_url)
        {
            // TIMO feedback: Hoe werkt dat nou, een PUT of een POST?
            // TIMO feedback: fix de kebab ofzo
            // TIMO feedback: Wat als wine niet bestaat?
            // collect.getbyid(...bla)
            // if (wineModel == null) DePleurisBreektUit();
            // wineModel.Update(name, description, tasteTags, image_url, wineRepository);
            _wineCollection.Update(wineId, name, description, tasteTags, image_url);
        }
    }
}
