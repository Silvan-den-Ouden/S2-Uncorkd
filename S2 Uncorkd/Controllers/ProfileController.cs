using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using S2_Uncorkd.ViewModels;
using Uncorkd_BLL.Collections;
using Uncorkd_BLL.Models;
using Uncorkd_DAL.Repositories;

namespace S2_Uncorkd.Controllers
{
    public class ProfileController : Controller
    {

        private readonly static ReviewRepository _reviewRepository = new();
        private readonly static WineRepository _wineRepository = new();
        private readonly static WineryRepository _wineryRepository = new();
        private readonly static TasteTagRepository _tasteTagRepository = new();

        private readonly static TasteTagCollection _tasteTagCollection = new(_tasteTagRepository);
        private readonly static WineryCollection _wineryCollection = new(_wineryRepository);
        private readonly static WineCollection _wineCollection = new(_wineryCollection, _tasteTagCollection, _wineRepository);
        private readonly ReviewCollection _reviewCollection = new(_wineCollection, _tasteTagCollection, _reviewRepository);


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reviews(int user_id, int page)
        {
            List<ReviewModel> reviews = _reviewCollection.GetWithUserID(user_id, page);
          
            return View(reviews);
        }
    }
}
