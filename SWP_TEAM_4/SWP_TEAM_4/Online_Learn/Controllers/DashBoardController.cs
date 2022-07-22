using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Online_Learn.AuthData;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers {

    public class DashBoardController : Controller {

        public IActionResult Index()
        {
            return View();
        }
    }
}
