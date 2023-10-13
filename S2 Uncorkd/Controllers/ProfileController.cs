using Microsoft.AspNetCore.Mvc;
using Uncorkd_BLL.Collections;

namespace S2_Uncorkd.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ReviewCollection _reviewCollection = new();
        private readonly TasteTagCollection _treatTagCollection = new();
        private readonly WineCollection _wineCollection = new();
        private readonly WineryCollection _wineryCollection = new();



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reviews()
        {
            
            return View();
        }
    }
}
