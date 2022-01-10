using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Channels;
using ManagerChannel.Models.ManagementProject;
using ManagerChannel.Models.Networks;
using ManagerChannel.Models.Regulations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerChannel.Models.Teams
{
    public class Team : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        // team hierarchical
        public string ParentTeamId { get; set; }
        public Team ParentTeam { get; set; }
        public List<Team> SubTeams { get; set; }

        // authrzation
        public List<UserRoleInTeam> UserRolesInTeam { get; set; }
        public List<Team_Regulation> Team_Regulations { get; set; }
        //------------------------------------------
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public class UserRoleInTeam : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string RoleId { get; set; }
        public RoleInTeam Role { get; set; }

        public string TeamId { get; set; }
        public Team Team { get; set; }

        public List<UserRole_YoutubeChannel> UserRole_YoutubeChannels { get; set; }
        public List<Network_UserRoleInTeam> NetWorkRoles { get; set; }
        public List<Project_UserRoleInTeam> ProjectRoles { get; set; }
        //-------------------------------------------------------------------------
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public class RoleInTeam : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<RolePermissionInTeam> RolePermissions { get; set; }
        public List<UserRoleInTeam> UserRoles { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public class RolePermissionInTeam : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [Required]
        public string RoleId { get; set; }
        public RoleInTeam Role { get; set; }

        public TeamPermission Permission { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public enum TeamPermission
    {
        // Quản lý Thành viên trong team
        MemberManager = 0100000000,                   // Quản lý Thành viên trong team    | Cho phép : Thêm/sửa/xóa/xem/phân_quyền thành viên trong team
        
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Quản lý các kênh trong team 
        ChannelsManagementInTeam = 0200000000,        // Quản lý các kênh trong team      | Cho phép : Thêm/sửa/xóa/xem/phân_quyền các kênh trong team

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Quản lý các kênh trong project
        ChannelsManagementInProject = 0300000000,     // Quản lý các kênh trong project   | Cho phép : Xem các kênh trong project trong team

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Quản lý các network trong team
        NetWorksManagementInTeam = 0400000000,        // Quản lý các network trong team   | Cho phép : Xem các kênh có sử dụng network trong team

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Thống kê dữ liệu
        DataAnalyst = 0500000000,                     // Thống kê dữ liệu                 | Cho phép : Xem tất cả các kênh trong team

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        // Quản lý kênh của người dùng
        UserChannelsManagement = 0600000000,          // Quản lý kênh của người dùng      | Cho phép : Thay đổi/chỉnh sửa/thêm mới - các video, nội dung trong kênh của user đó
    }
}
