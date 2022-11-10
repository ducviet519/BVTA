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
        public async Task<IActionResult> InsertOrUpdateRole(Roles role)
        {
            string message = "";
            try
            {
                string result = "";
                if (!String.IsNullOrEmpty(role.RoleID))
                {
                    result = await _services.Login.UpdateRole(role);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã cập nhật lại thông tin cho role: {role.RoleName}";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                    }
                }
                else
                {
                    result = await _services.Login.InsertRole(role);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã thêm mới role: {role.RoleName}";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                    }
                }
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return BadRequest(new { Message = message });
            }
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            string message = "";
            try
            {
                string result = "";
                if (!String.IsNullOrEmpty(id))
                {
                    result = await _services.Login.DeleteRole(id);
                    if (result == "OK")
                    {
                        message = $"Thành công! Đã xóa role";
                    }
                    else
                    {
                        message = $"Lỗi! {result}";
                    }
                }
                return Ok(new { Message = message });
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return BadRequest(new { Message = message });
            }
        }
    }
}
