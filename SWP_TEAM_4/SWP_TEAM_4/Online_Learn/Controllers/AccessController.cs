using Microsoft.AspNetCore.Mvc;

namespace Online_Learn.Controllers {
    public class AccessController : Controller {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
