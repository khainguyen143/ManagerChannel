using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Authorization
{
    public class RolePermission : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [Required]
        public string RoleId { get; set; }
        public Role Role { get; set; }

        public Permission Permission { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    /*
     * Nếu đặt giá trị permission theo tăng từ 1,2,3... thì sau này muốn chèn thêm permission vào giữa k được => phải đẩy ra cuối => loạn
     * 
     * Quy tắc đặt giá trị cho value: dd.dd.dd.dd.dd.dd
     * 10 chữ số = 5 level * 2 chữ số mỗi level
     * => api tối đa 5 level, mỗi level tối đa 99 giá trị
     * => đủ đáp ứng số lượng api endpoint
     * 
     * Ví dụ: 
     * 
     * api                          | permission                    | permission value
     * _____________________________|_______________________________|____________________
     * authorization                | Authorization                 | 01.00.00.00.00
     * authorization/role           | Authorization_Role            | 01.01.00.00.00
     * GET:authorization/role       | Authorization_Role_Get        | 01.01.01.00.00
     * POST:authorization/role      | Authorization_Role_Add        | 01.01.02.00.00
     * authorization/permission     | Authorization_Permission      | 01.02.00.00.00
     * 
    */
    public enum Permission
    {

        Access_Application = 0,

        /*---------------------------AUTHORIZATION---------------------------*/
        Authorize_User = 0100000000,

        /*---------------------------NOTIFICATION---------------------------*/
        Manage_Notification = 0200000000,

        /*---------------------------SERVICE---------------------------*/
        Manage_Service = 0300000000,

        /*---------------------------Tutorial---------------------------*/
        Manage_Tutorial = 0400000000,
    }
}
