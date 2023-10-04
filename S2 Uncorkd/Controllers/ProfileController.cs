using Microsoft.AspNetCore.Mvc;

namespace S2_Uncorkd.Controllers
{
    public class ProfileController : Controller
    {
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
