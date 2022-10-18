using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    public class CoXuongKhopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpGet]
        public IActionResult TongQuanKhamBenh()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DanhSachDangKyKCB()
        {
            return PartialView("_DanhSachDangKyKCB");
        }

        [HttpGet]
        public IActionResult DanhSachChoKham()
        {
            return PartialView("_DanhSachChoKham");
        }

        [HttpGet]
        public IActionResult DanhSachDangLamCLS()
        {
            return PartialView("_DanhSachDangLamCLS");
        }
    }
}
