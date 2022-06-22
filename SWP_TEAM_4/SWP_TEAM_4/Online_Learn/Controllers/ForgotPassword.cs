using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers
{
    public class ForgotPassword : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
