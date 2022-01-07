using API.Models;
using API.Models.Authorization;
using System;

namespace ManagerChannel.Models.ManagementProject
{
    public class ProjectRegulation : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {


        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string ProjectId { get; set; }
        public Warning  Warning { get; set; }
        public Project Project { get; set; }

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
    //các cấp độ cảnh khi vi phạm 1 quy định 
    public enum Warning
    {

    }
}
