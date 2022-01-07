using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Teams;
using System;

namespace ManagerChannel.Models.Role
{
    public class UserRole : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string TeamId { get; set; }
        public Team Team { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string FunctionId { get; set; }
        public Function Function { get; set; }
        public string RoleId { get; set; } // quyền hành động của user thuộc team  đối với chức năng đó vd : team IT , User Thể có các quyền thêm sửa, xóa ,...
        public Role Role { get; set; } // quyền hành động của user thuộc team  đối với chức năng đó vd : team IT , User Thể có các quyền thêm sửa, xóa ,...


        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

}
