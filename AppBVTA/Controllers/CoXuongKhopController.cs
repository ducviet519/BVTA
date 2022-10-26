﻿using DataBVTA.Models.Entities;
using DataBVTA.Models.ViewModels;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    public class CoXuongKhopController : Controller
    {
        private readonly IUnitOfWork _services;
        public CoXuongKhopController(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            DanhSachDangKyKhamBenh model = new DanhSachDangKyKhamBenh();
            model.DanhSachChoKham = await _services.DanhSachChoKham.DanhSachChoKhamAsync();
            return View(model);
        }

        #region Tổng quan danh sách đăng ký khám chữa bệnh

        [HttpGet]
        public async Task<IActionResult> TongQuanKhamBenh()
        {  
            DanhSachDangKyKhamBenh model = new DanhSachDangKyKhamBenh();
            model.PhongKham = new SelectList(await _services.PhongKham.DanhSachPhongKhamAsync(), "makp", "tenkp");
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> SearchTable(string phongKham)
        {
            string ngayKham = DateTime.Now.ToString("yyyyMMdd");
            return Json(new { data = await _services.DanhSachChoKham.DanhSachChoKhamAsync(ngayKham, phongKham) });
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
        public IActionResult ThemMoiChiDinh()
        {
            return View();
        }
        #endregion

        #region 4. Danh sách đơn thuốc
        public IActionResult DanhSachDonThuoc()
        {
            return View();
        }
        public IActionResult ThemMoiDonThuoc()
        {
            return PartialView("_ThemMoiDonThuoc");
        }
        public IActionResult SuaDonThuoc()
        {
            return PartialView("_SuaDonThuoc");
        }
        #endregion

        #region 5. Xử trí
        public IActionResult XuTri()
        {
            return View();
        }
        #endregion
    }
}
