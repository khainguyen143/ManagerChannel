using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Regulations;
using ManagerChannel.Models.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerChannel.Models.ManagementProject
{
    public class Project : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public string ManagementId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }

        public List<Project_UserRoleInTeam> Project_UserRoleInTeams { get; set; }
        public List<Project_Regulation> Project_Regulations { get; set; }

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

    public class Project_UserRoleInTeam
    {
        [Required]
        public string UserRoleInTeamId { get; set; }
        public UserRoleInTeam UserRoleInTeam { get; set; }

        [Required]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
