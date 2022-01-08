using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Networks;
using ManagerChannel.Models.Pay;
using System;
using System.Collections.Generic;
using ManagerChannel.Models.Teams;
using ManagerChannel.Models.ProjectGoogleApies;

namespace ManagerChannel.Models.Channels
{
    public class YoutubeChannel : ISoftDeletableModel, ILoggableUserActionModel
    {
        public string ChannelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Etag { get; set; }
        
        public DateTime PublishedAt { get; set; }
        public string LinkThumbnails_High { get; set; }

        public int CountVideo { get; set; }
        public long ViewCount { get; set; }
        public long SubscriberCount { get; set; }
        public bool HiddenSubscriberCount { get; set; }
        public string Token { get; set; }

        public DateTime? StartPayment { get; set; }
        public string NetworkId { get; set; }
        public NetWork NetWork { get; set; }
        public float NetworkRate { get; set; }

        public string ProjectGoogleApiId { get; set; }
        public ProjectGoogleApi ProjectGoogleApi { get; set; }
        public List<Video> Videos { get; set; }
        public List<UserRole_YoutubeChannel> UserRole_YoutubeChannels { get; set; }
        public List<User_YoutubeChannelHistory>  UserChannelHistories { get; set; }
        public List<Network_Channel_History> NetWorkHistories { get; set; }
        public List<ReportDataChannelDaily> ReportDataChannelDailies { get; set; }
        //-----------------------------------------
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public class UserRole_YoutubeChannel
    {
        public string ChannelId { get; set; }
        public YoutubeChannel YoutubeChannel { get; set; }

        public string UserRoleInTeamId { get; set; }
        public UserRoleInTeam UserRoleInTeam { get; set; }
    }

    public class User_YoutubeChannelHistory : ISoftDeletableModel
    {
        public string Id { get; set; }
        public int ChannelId { get; set; }
        public YoutubeChannel YoutubeChannel { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        //------------------------------------------
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
    public class Network_Channel_History : BaseModel
    {
        public string ChannelId { get; set; }
        public YoutubeChannel YoutubeChannel { get; set; }

        public string Network_UserRoleInTeamId { get; set; }
        public Network_UserRoleInTeam Network_UserRoleInTeam { get; set; }

        public string PaymentAccountId { get; set; }
        public PaymentAccount PaymentAccount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float NetworkRate { get; set; }

    }
    public class ReportDataChannelDaily : BaseModel
    {
        public string ChannelId { get; set; }
        public YoutubeChannel YoutubeChannel { get; set; }

        public long ViewCount { get; set; }
        public float AverageViewDurationInSecond { get; set; }
        public bool IsMonetize { get; set; }
        public long ViewGain { get; set; }
        public long RevenueGain { get; set; }

        public int CountVideo { get; set; }
        public long SubscriberCount { get; set; }
        public long SubscriberGain { get; set; }
        public string Network_UserRoleInTeamId { get; set; }
        public Network_UserRoleInTeam Network_UserRoleInTeam { get; set; }
        public float NetworkRate { get; set; }
        public int USRevenueGain { get; set; }
    }
}
