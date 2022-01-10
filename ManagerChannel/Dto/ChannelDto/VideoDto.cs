using API.Dto;
using System;

namespace ManagerChannel.Dto.ChannelDto
{
    public class VideoDto : BaseDto
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
    }

    public class ReportDataVideoDailyDto : BaseDto
    {
        public string VideoId { get; set; }
        public long ViewCount { get; set; }
        public int likeCount { get; set; }
        public float AverageViewDurationInSecond { get; set; }
        public bool IsMonetize { get; set; }
        public long ViewGain { get; set; }
        public long RevenueGain { get; set; }
    }
}
