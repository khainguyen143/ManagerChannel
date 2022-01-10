using ManagerChannel.Dto.BaseDtos;
using System;

namespace ManagerChannel.Dto.ProjectDto
{
    public class ProjectDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public string ManagementId { get; set; }
        public DateTime StartDate { get; set; }
    }
    public class Project_UserRoleInTeamDto
    {
        public string UserRoleInTeamId { get; set; }
        public string ProjectId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
