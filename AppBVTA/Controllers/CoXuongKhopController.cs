using DataBVTA.Models.Entities;
using DataBVTA.Models.ViewModels;
using DataBVTA.Services;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    [Authorize]
    public class CoXuongKhopController : Controller
    {
        private readonly IUnitOfWork _services;
        public CoXuongKhopController(IUnitOfWork services)
        {
            _services = services;
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
        public async Task<JsonResult> GetDanhSachChoKham(string param, string ngayKham,string phongKham, string mabn)
        {
            var danhSachPK = await _services.PhongKham.DanhSachPhongKhamAsync();
            List<string> maPK = new List<string>();
            foreach (var pk in danhSachPK)
            {
                maPK.Add(pk.makp);
            }
            var data = await _services.DanhSachChoKham.DanhSachChoKhamAsync(param, phongKham, mabn, ngayKham);
            if (String.IsNullOrEmpty(phongKham) == true || phongKham == "-1")
            {
                data = data.Where(s => maPK.Contains(s.maphongkham)).ToList();
            }
            return Json(new { data });
        }

        [HttpGet]
        public IActionResult DanhSachDangKyKCB()
        {
            return PartialView("_DanhSach_DangKyKCB");
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachChuaKham(string mapk)
        {
            DanhSachDangKyKhamBenh model = new DanhSachDangKyKhamBenh();
            model.DanhSachChoKham = await _services.DanhSachChoKham.DanhSachChoKhamAsync("2", mapk);
            return PartialView("_DanhSach_ChiTietChuaKham", model);
        }

        [HttpGet]
        public IActionResult DanhSachChoKham()
        {
            return PartialView("_DanhSach_ChoKham");
        }

        [HttpGet]
        public IActionResult DanhSachDangLamCLS()
        {
            return PartialView("_DanhSach_DangLamCLS");
        }

        #endregion

        #region Thông tin chung của bệnh nhân
        //public async Task<IActionResult> ThongTinBenhNhan()
        //{

        //    //model.Depts = new SelectList(await _depts.GetAll_DeptsAsync(), "STT", "KhoaP");

        //    return PartialView("_ThongTinBenhNhan");
        //}
        //public IActionResult DanhMuc()
        //{
        //    return PartialView("_DanhMuc");
        //}
        //public IActionResult BieuDo()
        //{
        //    return PartialView("_BieuDo");
        //}
        [HttpGet]
        public async Task<JsonResult> GetLichSuKhamBenh(string mabn, string ngaykham = null, string maql = null, string thang = null)
        {
            List<TreeData> dataTree = new List<TreeData>();
            List<LichSuKhamBenh> lichsuKB = await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn, ngaykham, maql, thang);
            foreach(var ls in lichsuKB)
            {
                TreeData tree = new TreeData() {
                    text = $"{ls.ngaykham} {ls.tenkhoaphong}",
                    href = @"#",
                    nodes = new List<TreeData>() { 
                        new TreeData() { text = $"Đối tượng: {ls.doituong}"},
                        new TreeData() { text = $"Chẩn đoán: {ls.chandoan}"},
                        new TreeData() { text = $"Bác sĩ: {ls.tenbacsi}"},
                    }
                };
                dataTree.Add(tree);
            }
            return Json(new { dataTree });
        }
        #endregion

        #region 1. Khám lâm sàng

        public async Task<IActionResult> PhieuKhamBenh(string mabn, string maphongkham)
        {
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.LichSuKhamBenh = await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn);
            model.ThongTinHanhChinh = (await _services.ThongTinHanhChinh.GetThongTinHanhChinh(mabn)).Where(i => i.mabn != null).FirstOrDefault();
            //string mavaovien = (await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn))
            return View(model);
        }
       
        [HttpGet]
        public IActionResult KhamLamSang()
        {

            return PartialView("_PhieuKhamBenh_KhamLamSang");
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
