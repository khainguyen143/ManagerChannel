using API.Dto;
using ManagerChannel.Dto.ChannelDto;
using ManagerChannel.Models.ProjectGoogleApies;
using System.Collections.Generic;

namespace ManagerChannel.Dto.ProjectGoogleApiDtos
{
    public class ProjectGoogleApiDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public int CountQuotaimpact { get; set; }
        public List<YoutubeChannelDto> YoutubeChannels { get; set; }
        public TypeProjectGoogleApi TypeProjectGoogleApi { get; set; }
    }
}
