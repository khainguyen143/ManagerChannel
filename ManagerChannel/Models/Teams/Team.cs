using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;

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
        public List<TeamUserRole> UserRoles { get; set; }

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

    public class TeamUserRole
    {
        public string TeamId { get; set; }
        public Team Team { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public TeamRole Role { get; set; }  
    }

    public enum TeamRole
    {
        Leader = 0,         // role: Trưởng nhóm            | Team con: xem + thêm + sửa + xóa        | quản lý user
        DataAnalyst = 1,    // role: Thống kê dữ liệu       | Team con: xem 
        Staff = 2           // role: Nhân viên              | Team con: không 
    }
}
