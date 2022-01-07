using API.Models;

using API.Models.Authorization;
using ManagerChannel.Models.Teams;
using System;

namespace ManagerChannel.Models.Role
{
    public class Role : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string ParentId { get; set; }
        public string RoleName { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        //Quản lý network
        //  - Quản lý // => thêm - sửa - xóa - thống kê
        //  - thêm
        //  - sửa 
        //  - quản lý user ,.....
        //  - xóa
        //  - Thống kê ,....
        //-Quản lý Project
        //
        //
    }
}
