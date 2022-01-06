using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Constants
{
    public static class AuthConst
    {
        public static string ApplicationAdminUserName = "admin";
        public static string ApplicationAdminUserId = "92ad4f43-4be7-4fb8-909f-ced532c58461";

        public static string ApplicationAdminRoleName = "application_admin";
        public static string ApplicationAdminRoleId = "4d01b5d9-6458-4258-a03d-7852ac6c43a9";

        public static string ApplicationUserRoleName = "application_user";
        public static string ApplicationUserRoleId = "4d01b5d9-6458-4258-a03d-7852ac6c43b8";

        public static List<PermissionDetail> Permissions = new List<PermissionDetail>
        {
            new PermissionDetail { Permission = Permission.Access_Application, Name = "Truy cập ứng dụng", Description = "" },
            new PermissionDetail { Permission = Permission.Authorize_User, Name = "Quản lý phân quyền", Description = "" },
            new PermissionDetail { Permission = Permission.Manage_Notification, Name = "Quản lý thông báo", Description = "" },
            new PermissionDetail { Permission = Permission.Manage_Service, Name = "Quản lý dịch vụ", Description = "" },
        };
    }

    public class PermissionDetail
    {
        public Permission Permission { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
