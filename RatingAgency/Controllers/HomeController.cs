using Microsoft.AspNetCore.Mvc;

namespace RatingAgency.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
