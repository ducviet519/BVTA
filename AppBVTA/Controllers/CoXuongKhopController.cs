using DataBVTA.Models.Entities;
using DataBVTA.Models.ViewModels;
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

        #region Thông tin chung của bệnh nhân
        public IActionResult ThongTinBenhNhan()
        {
            return PartialView("_ThongTinBenhNhan");
        }
        public IActionResult DanhMuc()
        {
            return PartialView("_DanhMuc");
        }
        public IActionResult BieuDo()
        {
            return PartialView("_BieuDo");
        }
        #endregion

        #region 1. Khám lâm sàng

        public IActionResult PhieuKhamBenh()
        {
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            var data = new ThongTinBenhNhan() { id = "0123456789" };
            model.BenhNhan = data;
            return View(model);
        }

        [HttpGet]
        public IActionResult KhamLamSang()
        {
            
            return PartialView("_KhamLamSang");
        }
        [HttpPost]
        public IActionResult KhamLamSang(string id)
        {
            return RedirectToAction("PhieuKhamBenh");
        }

        

        #endregion

        #region 2. Đánh giá

        public IActionResult DanhGiaASDAS()
        {
            return View();
        }
        public IActionResult DanhGiaDAPSA()
        {
            return View();
        }
        public IActionResult DanhGiaPASI()
        {
            return View();
        }

        #endregion

        #region 3. Chỉ định

        public IActionResult ChiDinh()
        {
            return View();
        }
        public IActionResult KetQuaChanDoanHinhAnh()
        {
            return PartialView("_KetQuaChanDoanHinhAnh");
        }
        public IActionResult KetQuaXetNghiem()
        {
            return PartialView("_KetQuaXetNghiem");
        }
        #endregion
    }
}
