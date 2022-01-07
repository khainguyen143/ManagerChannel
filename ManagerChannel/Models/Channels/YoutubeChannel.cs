using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Networks;
using ManagerChannel.Models.Pay;
using System;
using System.Collections.Generic;
using ManagerChannel.Models.ManagementProject;

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

        public string ViewCount { get; set; }
        public string SubscriberCount { get; set; }
        public bool HiddenSubscriberCount { get; set; }
        public string VideoCount { get; set; }
        public string Token { get; set; }

        public string PaymentAccountId { get; set; }
        public PaymentAccount PaymentAccount { get; set; }
        public DateTime? StartPayment { get; set; }
        public string NetworkId { get; set; }
        public NetWork NetWork { get; set; }
        public float NetworkRate { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
       
        public List<User_YoutubeChannel>  UserChannelHistories { get; set; }
        public List<NetworkHistory> NetWorkHistories { get; set; }
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

    public class User_YoutubeChannel : ISoftDeletableModel
    {
        public string Id { get; set; }
        public int ChannelId { get; set; }
        public YoutubeChannel Channel { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        //------------------------------------------
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
    public class NetworkHistory : BaseModel
    {
        public string ChannelId { get; set; }
        public YoutubeChannel YoutubeChannel { get; set; }

        public string NetWorkId { get; set; }
        public NetWork NetWork { get; set; }

        public string PaymentAccountId { get; set; }
        public PaymentAccount PaymentAccount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float NetworkRate { get; set; }

    }
}
