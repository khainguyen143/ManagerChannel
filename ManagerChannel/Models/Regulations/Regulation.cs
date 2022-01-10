using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.ManagementProject;
using ManagerChannel.Models.Networks;
using ManagerChannel.Models.Teams;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Models.Regulations
{
    public class Regulation : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public List<Project_Regulation> Project_Regulations { get; set; }
        public List<Network_Regulation> Network_Regulations { get; set; }
        public List<Team_Regulation> Team_Regulations { get; set; }

        /*----------------------------------------------*/
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
    }
    public class Project_Regulation
    {
        public string ProjectId { get; set; }
        public Project Project { get; set; }

        public string RegulationId { get; set; }
        public Regulation Regulation { get; set; }
    }

    public class Network_Regulation
    {
        public string NetworkId { get; set; }
        public Network NetWork { get; set; }

        public string RegulationId { get; set; }
        public Regulation Regulation { get; set; }
    }

    public class Team_Regulation
    {
        public string TeamId { get; set; }
        public Team Team { get; set; }

        public string RegulationId { get; set; }
        public Regulation Regulation { get; set; }
    }
}
