using API.Models;

namespace ManagerChannel.Models.Role
{
    public class UserRole : BaseModel
    {
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public string FunctionId { get; set; }
        public string RoleId { get; set; } // quyền hành động của user thuộc team  đối với chức năng đó vd : team IT , User Thể có các quyền thêm sửa, xóa ,...
      
    }

}
