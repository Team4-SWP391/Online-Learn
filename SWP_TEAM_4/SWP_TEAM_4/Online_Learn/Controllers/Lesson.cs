using Microsoft.AspNetCore.Mvc;

namespace Online_Learn.Controllers
{
    public class Lesson : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
