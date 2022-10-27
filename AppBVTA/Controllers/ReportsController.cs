using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PhieuKhamBenh()
        {
            return new ViewAsPdf("PhieuKhamBenh");
        }

        public IActionResult DemoViewAsPDF()
        {
            return new ViewAsPdf("DemoViewAsPDF");
        }
    }
}
