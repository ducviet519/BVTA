using Dapper;
using DataBVTA.Models;
using DataBVTA.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        #region Connection Database

        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            provideName = "System.Data.SqlClient";
        }
        public string ConnectionString { get; }
        public string provideName { get; }
        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        #endregion

        #region Delete Item
        public async Task<string> DeleteAction(string id)
        {
            string result = "";
            var query = "DELETE FROM ModuleActions WHERE ActionID = @ActionID";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync(query, new { ActionID = id });
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> DeleteController(string id)
        {
            string result = "";
            var query = "DELETE FROM ModuleControllers WHERE ControllerID = @ControllerID";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync(query, new { ControllerID = id });
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> DeleteNavigationMenu(string id)
        {
            string result = "";
            var query = "DELETE FROM NavigationMenu WHERE MenuID = @MenuID";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync(query, new { MenuID = id });
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> DeleteRole(string id)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.ExecuteAsync("sp_Auth_Roles", new { RoleID = id });
                    if (data != 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }
        #endregion

        #region Get List Item
        public async Task<List<ModuleAction>> GetActions()
        {
            List<ModuleAction> data = new List<ModuleAction>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<ModuleAction>("sp_Report_Version_View", commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<ModuleController>> GetControllers()
        {
            List<ModuleController> data = new List<ModuleController>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<ModuleController>("sp_Report_Version_View", commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<NavigationMenu>> GetNavigationMenus()
        {
            List<NavigationMenu> data = new List<NavigationMenu>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<NavigationMenu>("sp_Report_Version_View", commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<Roles>> GetRoles()
        {
            List<Roles> data = new List<Roles>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<Roles>("sp_Auth_Roles", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<UserInRole>> GetUserInRole(string username = null, string userId = null)
        {
            List<UserInRole> data = new List<UserInRole>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<UserInRole>("sp_Report_Version_View",
                        new
                        {
                            UserName = username,
                            UserID = userId

                        },
                        commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<UserMenuPermission>> GetUserMenuPermissions(string userId = null, string username = null, string menuId = null, string menuname = null)
        {
            List<UserMenuPermission> data = new List<UserMenuPermission>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<UserMenuPermission>("sp_Report_Version_View",
                        new
                        {
                            UserID = userId,
                            UserName = username,
                            MenuID = menuId,
                            MenuName = menuname
                        },
                        commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }

        public async Task<List<Users>> GetUsers()
        {
            List<Users> data = new List<Users>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    data = (await dbConnection.QueryAsync<Users>("sp_Auth_Users", new { Action = "GetAll" }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }
        #endregion

        #region Add Item
        public async Task<string> InsertAction(ModuleAction action, string user = null)
        {
            string result = "";
            var query = "INSERT INTO dbo.ModuleActions(ActionID, Name, CreatedBy, DateCreated) VALUES(NEWID(), @ActionName, @User, GETDATE());";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<ModuleAction>(query
                        , new
                        {
                            ActionName = action.Name,
                            User = user

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public Task<string> InsertController()
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertNavigationMenu()
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertRole(Roles role, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<Roles>("sp_Auth_Roles"
                        , new
                        {
                            Action = "Add",
                            RoleName = role.RoleName,
                            Description = role.Description,
                            Status = role.Status,
                            User = user

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public async Task<string> InsertUsers(Users users)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var data = await dbConnection.QueryAsync<Users>("sp_Auth_Users",
                        new
                        {
                            DisplayName = users.DisplayName,
                            UserName = users.UserName,
                            Password = users.Password,
                            Source = users.Source,
                            Email = users.Email,
                            Status = users.Status,
                            Action = "Add"
                        },
                        commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public Task<string> AddUserMenuPermissions()
        {
            throw new NotImplementedException();
        }

        public Task<string> AddUserRole()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Check Exist
        public Task<bool> IsUserHasPermission()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserHasRole()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Edit Item
        public Task<string> UpdateAction(ModuleAction action, string user = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateController()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateNavigationMenu()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateRole(Roles role, string user = null)
        {
            string result = "";
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = await dbConnection.QueryAsync<Roles>("sp_Auth_Roles"
                        , new
                        {
                            Action = "Edit",
                            RoleID = role.RoleID,
                            RoleName = role.RoleName,
                            Description = role.Description,
                            Status = role.Status,
                            User = user

                        }
                        , commandType: CommandType.StoredProcedure);
                    if (data != null)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }

        #endregion
    }
}
