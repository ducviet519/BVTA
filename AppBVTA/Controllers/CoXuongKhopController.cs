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

        #region Tổng quan danh sách đăng ký khám chữa bệnh

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
        public IActionResult DanhSachChiTietBenhNhanChoKham()
        {
            return PartialView("_DanhSachChiTietBenhNhanChoKham");
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

        #endregion

        public IActionResult ThongTinBenhNhan()
        {
            return PartialView("_ThongTinBenhNhan");
        }
        public IActionResult PhieuKhamBenh()
        {
            return View();
        }
        
    }
}
