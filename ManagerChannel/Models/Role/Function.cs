using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Teams;
using System;
namespace ManagerChannel.Models.Role
{
    public class Function : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Code { get; set; }// Ma chuc nang vd :  chức năng Network : NETWORK
        public string Name { get; set; }// ten chuc nang : quản lý network
        public string Note { get; set; }
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
