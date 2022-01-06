using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Authorization
{
    public class Role : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser {get;set;}
        public string UpdatedByUserId {get;set;}
        public User UpdatedByUser {get;set;}
        public string DeletedByUserId {get;set;}
        public User DeletedByUser {get;set;}

        public bool IsDeleted {get;set;}
        public DateTime? DeletedDate {get;set;}
    }
}
