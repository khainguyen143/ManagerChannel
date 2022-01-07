using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Channels;
using ManagerChannel.Models.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerChannel.Models.Networks
{
    public class NetWork : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Name { get; set; }
        public string Note { get; set; }

        public List<NetworkHistory> NetWorkHistories { get; set; }
        public List<Network_UserRoleInTeam> NetWorkRoles { get; set; }
        //----------------------------------------
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
    }

    public class Network_UserRoleInTeam
    {
        [Required]
        public string UserRoleInTeamId { get; set; }
        public UserRoleInTeam UserRoleInTeam { get; set; }

        [Required]
        public string NetworkId { get; set; }
        public NetWork NetWork { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
