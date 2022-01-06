using API.Models;
using API.Models.Authorization;
using System;

namespace ManagerChannel.Models.Project
{
    public class Project : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime StartDate { get; set; }
        public string UserId { get; set; }  
        public User User { get; set; }
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
}
