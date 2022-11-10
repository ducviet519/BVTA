using DataBVTA.Models;
using DataBVTA.Models.ViewModels;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _services;
        public AdminController(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<IActionResult> Permission()
        {
            PermissionViewModel model = new PermissionViewModel();
            model.ListUsers = await _services.Login.GetUsers();
            model.ListRoles = await _services.Login.GetRoles();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetRoles()
        {
            var data = (await _services.Login.GetRoles()).ToList();
            return Json(new { data });
        }

        [HttpPost]
        public async Task<JsonResult> InsertOrUpdateRole(Roles role)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                string user = User.Identity.Name;
                if (!String.IsNullOrEmpty(role.RoleID))
                {
                    result = await _services.Login.UpdateRole(role, user);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã cập nhật lại thông tin cho role: {role.RoleName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
                else
                {
                    result = await _services.Login.InsertRole(role, user);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã thêm mới role: {role.RoleName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }                
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }

        [HttpGet]
        public async Task<JsonResult> DeleteRole(string roleID, string roleName)
        {
            string message = "";
            string title = "";
            string result = "";
            try
            {
                if (!String.IsNullOrEmpty(roleID) || roleName == "Admin" || roleName == "User" || roleName == "Manager")
                {
                    result = await _services.Login.DeleteRole(roleID);
                    if (result == "OK")
                    {
                        message = $"Đã xóa thành công role: {roleName}";
                        title = "Thành công!";
                        result = "success";
                    }
                    else
                    {
                        message = $"{result}";
                        title = "Lỗi!";
                        result = "error";
                    }
                }
                else 
                {   message = $"Lỗi! Không thể xóa Role mặc định";
                    title = "Lỗi!";
                    result = "error";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                title = "Lỗi!";
                result = "error";
            }
            return Json(new { Result = result, Title = title, Message = message });
        }
    }
}
