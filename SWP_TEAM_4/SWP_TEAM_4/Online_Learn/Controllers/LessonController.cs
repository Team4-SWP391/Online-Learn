using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Online_Learn.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers
{
    public class LessonController : Controller
    {
        private readonly Online_LearnContext _context;

        public LessonController(Online_LearnContext context)
        {
            _context = context;
        }


    }
}
