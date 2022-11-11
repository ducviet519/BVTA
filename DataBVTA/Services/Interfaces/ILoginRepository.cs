﻿using DataBVTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    
    public interface ILoginRepository
    {
        public Task<List<Roles>> GetRoles();
        public Task<string> InsertRole(Roles role, string user = null);
        public Task<string> UpdateRole(Roles role, string user = null);
        public Task<string> DeleteRole(string id);

        public Task<List<Users>> GetUsers();
        public Task<string> InsertUsers(Users users);

        public Task<List<ModuleController>> GetControllers();
        public Task<string> InsertController(ModuleController controller, string user = null);
        public Task<string> UpdateController(ModuleController controller, string user = null);
        public Task<string> DeleteController(string id);

        public Task<List<ModuleAction>> GetActions();
        public Task<string> InsertAction(ModuleAction action, string user = null);
        public Task<string> UpdateAction(ModuleAction action, string user = null);
        public Task<string> DeleteAction(string id);

        public Task<List<NavigationMenu>> GetNavigationMenus();
        public Task<string> InsertNavigationMenu(NavigationMenu menu, string user = null);
        public Task<string> UpdateNavigationMenu();
        public Task<string> DeleteNavigationMenu(string id);

        public Task<List<UserInRole>> GetUserInRole(string username = null, string userId = null);
        public Task<string> AddUserRole();

        public Task<List<UserMenuPermission>> GetUserMenuPermissions(string userId = null, string username = null, string menuId = null, string menuname = null);
        public Task<string> AddUserMenuPermissions();

        public Task<bool> IsUserHasRole();
        public Task<bool> IsUserHasPermission();

    }
}