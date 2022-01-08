using API.Models;
using API.Models.Authorization;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Models.Channels
{
    public class Video : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublicDate { get; set; }
        public bool IsClamed { get; set; }
        public bool IsDeletedByChannelManager { get; set; }
        public string LinkThumbnails_High { get; set; }

        public long ViewCount { get; set; }
        public long LikeCount { get; set; }
        public long CommentCount { get; set; }

        public string ChannelId { get; set; }
        public YoutubeChannel Channel { get; set; }
        public List<ReportDataVideoDaily> ReportDataVideoDailies { get; set; }
        //-----------------------------------------
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
    }

    public class ReportDataVideoDaily : BaseModel
    {
        public string VideoId { get; set; }
        public Video Video { get; set; }

        public long ViewCount { get; set; }
        public float AverageViewDurationInSecond { get; set; }
        public bool IsMonetize { get; set; }
        public long ViewGain { get; set; }
        public long RevenueGain { get; set; }
    }
}
