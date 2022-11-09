using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
