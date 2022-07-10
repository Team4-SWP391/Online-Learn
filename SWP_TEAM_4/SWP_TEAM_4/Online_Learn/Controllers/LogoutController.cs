using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Online_Learn.Controllers {
    public class LogoutController : Controller {
        // GET: Logout
        public IActionResult Index()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Clear();
            return Redirect("Home");
        }
    }
}
