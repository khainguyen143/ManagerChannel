using ManagerChannel.Dto.BaseDtos;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Dto.ChannelDto
{
    public class YoutubeChannelDto : BaseDto
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
        public float NetworkRate { get; set; }

        public string ProjectGoogleApiId { get; set; }
    }

    public class User_YoutubeChannelHistoryDto 
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        //------------------------------------------
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class UserRole_YoutubeChannelDto
    {
        public string ChannelId { get; set; }
        public string UserRoleInTeamId { get; set; }
    }

    public class Network_Channel_HistoryDto : BaseDto
    {
        public string ChannelId { get; set; }
        public string Network_UserRoleInTeamId { get; set; }
        public string PaymentAccountId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float NetworkRate { get; set; }
    }

    public class ReportDataChannelDailyDto : BaseDto
    {
        public string ChannelId { get; set; }

        public long ViewCount { get; set; }
        public float AverageViewDurationInSecond { get; set; }
        public bool IsMonetize { get; set; }
        public long ViewGain { get; set; }
        public long RevenueGain { get; set; }

        public int CountVideo { get; set; }
        public long SubscriberCount { get; set; }
        public long SubscriberGain { get; set; }
        public string Network_UserRoleInTeamId { get; set; }
        public float NetworkRate { get; set; }
        public int USRevenueGain { get; set; }
    }
}
