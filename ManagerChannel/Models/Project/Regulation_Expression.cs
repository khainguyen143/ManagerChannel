using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.ManagementProject;
using System;
namespace ManagerChannel.Models.Project
{
    public class Regulation_Expression: BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        public string ProjectRegulationId { get; set; }
        public ProjectRegulation ProjectRegulation { get; set; }

        public string RegulationExpressionId { get; set; }
        public RegulationExpression RegulationExpression { get; set; }
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
