using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Channels;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Models.ProjectGoogleApies
{
    public class ProjectGoogleApi : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public int CountQuotaimpact { get; set; }
        public List<YoutubeChannel> YoutubeChannels { get; set; }
        public TypeProjectGoogleApi TypeProjectGoogleApi { get; set; }
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
    public enum TypeProjectGoogleApi
    {
        Youtube_Data_Api_V3,
        Youtube_Analytics,
    }
}
