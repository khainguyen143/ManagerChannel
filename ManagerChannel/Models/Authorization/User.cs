using API.Models.Notifications;
using ManagerChannel.Models.Channels;
using ManagerChannel.Models.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Authorization
{
    public class User : BaseModel, ISoftDeletableModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; }
        public string UserName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<UserRoleInTeam> UserRoleInTeams { get; set; }
        public List<UserRestriction> UserRestrictions { get; set; }
        public List<User_YoutubeChannelHistory> User_YoutubeChannelHistories { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate {get;set;}
    }
}
