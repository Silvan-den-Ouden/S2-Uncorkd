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
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();
        private readonly TasteTagCollection _tasteTagCollection = new();

        private readonly WineRepository _wineRepository = new();
        private readonly WineryRepository _wineryRepository = new();
        private readonly TasteTagRepository _tasteTagRepository = new();

        public IActionResult Index(int ID)
        {
            WineModel wineModel = _wineCollection.GetWithID(ID, _wineRepository, _wineryRepository, _tasteTagRepository);
       
            return View(wineModel);
        }

        public IActionResult Upload(int winery_ID)
        {
            WineryModel wineryModel = _wineryCollection.GetWithID(winery_ID, _wineryRepository);
            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll(_tasteTagRepository);

            UploadWineViewModel uploadViewModel = new(wineryModel, tasteTagModels);

            return View(uploadViewModel);
        }

        public IActionResult Update(int wine_ID)
        {
            WineModel wineModel = _wineCollection.GetWithID(wine_ID, _wineRepository, _wineryRepository, _tasteTagRepository);

            // TIMO feedback:
            if (wineModel == null)
            {
                return NotFound();
            }

            List<TasteTagModel> tasteTagModels = _tasteTagCollection.GetAll(_tasteTagRepository);

            UpdateWineViewModel updateViewModel = new(wineModel,tasteTagModels);

            return View(updateViewModel);
        }

        public void CreateWine(int wineryId, string name, string description, string tasteTags, string image_url)
        {
            _wineCollection.Create(wineryId, name, description, tasteTags, image_url, _wineRepository);
        }

        public void UpdateWine(int wineId, string name, string description, string tasteTags, string image_url)
        {
            // TIMO feedback: Hoe werkt dat nou, een PUT of een POST?
            // TIMO feedback: fix de kebab ofzo
            // TIMO feedback: Wat als wine niet bestaat?
            // collect.getbyid(...bla)
            // if (wineModel == null) DePleurisBreektUit();
            // wineModel.Update(name, description, tasteTags, image_url, wineRepository);
            _wineCollection.Update(wineId, name, description, tasteTags, image_url, _wineRepository);
        }
    }
}
