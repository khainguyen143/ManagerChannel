using API.Models;
using API.Models.Authorization;
using System;
namespace ManagerChannel.Models.Project
{
    public class RegulationExpression : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string Expression { get; set; }// biểu thức kiểm tra
        public string FieldColumn { get; set; }// cột sẽ được kiểm tra bởi biêu thức.

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
