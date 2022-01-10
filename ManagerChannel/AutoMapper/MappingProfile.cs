using AutoMapper;
using ManagerChannel.Dto.BaseDtos;
using ManagerChannel.Dto.ChannelDto;
using ManagerChannel.Dto.NetworksDto;
using ManagerChannel.Dto.PayDto;
using ManagerChannel.Dto.ProjectDto;
using ManagerChannel.Dto.ProjectGoogleApiDtos;
using ManagerChannel.Dto.TeamDtos;
using ManagerChannel.Models.Channels;
using ManagerChannel.Models.ManagementProject;
using ManagerChannel.Models.Networks;
using ManagerChannel.Models.Pay;
using ManagerChannel.Models.ProjectGoogleApies;
using ManagerChannel.Models.Teams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ManagerChannel.Dto.TeamDtos.FilterTeamDto;

namespace API.AutoMapper
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<Team, TeamDto>()
                    .MapToBaseViewModel()
                    .ReverseMap();

            CreateMap<AddTeamDto, Team>()
                .ReverseMap();
            CreateMap<EditTeamDto, Team>()
                .ReverseMap();

            CreateMap<UserRoleInTeam, UserRoleInTeamDto>().ReverseMap();
            CreateMap<UserRoleInTeamDto, UserRoleInTeam>().ReverseMap();

            CreateMap<RoleInTeam, RoleInTeamDto>().ReverseMap();
            CreateMap<RoleInTeamDto, RoleInTeam>().ReverseMap();

            CreateMap<RolePermissionInTeam, RolePermissionInTeamDto>()
                .ReverseMap();
            CreateMap<RolePermissionInTeamDto, RolePermissionInTeam>()
                .ReverseMap();

            CreateMap<Project, ProjectDto>()
                .MapToBaseViewModel()
                .ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();

            CreateMap<Project_UserRoleInTeam, Project_UserRoleInTeamDto>().ReverseMap();
            CreateMap<Project_UserRoleInTeamDto, Project_UserRoleInTeam>().ReverseMap();

            CreateMap<Network, NetworkDto>()
                .MapToBaseViewModel()
                .ReverseMap();
            CreateMap<NetworkDto, Network>().ReverseMap();

            CreateMap<Network_PaymentAccount, Network_PaymentAccountDto>()
                .MapToBaseViewModel()
                .ReverseMap();
            CreateMap<Network_PaymentAccountDto, Network_PaymentAccount>()
                .ReverseMap();

            CreateMap<PaymentAccount, PaymentAccountDto>()
                .MapToBaseViewModel()
                .ReverseMap();
            CreateMap<PaymentAccountDto, PaymentAccount>()
               .ReverseMap();

            CreateMap<Network_UserRoleInTeam, Network_UserRoleInTeamDto>().ReverseMap();
            CreateMap<Network_UserRoleInTeamDto, Network_UserRoleInTeam>().ReverseMap();

            CreateMap<UserRole_YoutubeChannel, UserRole_YoutubeChannelDto>().ReverseMap();
            CreateMap<UserRole_YoutubeChannelDto, UserRole_YoutubeChannel>().ReverseMap();

            CreateMap<ProjectGoogleApi, ProjectGoogleApiDto>()
                .MapToBaseViewModel()
                .ReverseMap();
            CreateMap<ProjectGoogleApiDto, ProjectGoogleApi>()
                .ReverseMap();

            CreateMap<ReportDataChannelDaily, ReportDataChannelDailyDto>()
                .MapToBaseViewModel()
                .ReverseMap();
            CreateMap<ReportDataChannelDailyDto, ReportDataChannelDaily>()
                .ReverseMap();

            CreateMap<Video, VideoDto>().MapToBaseViewModel().ReverseMap();
            CreateMap<VideoDto, Video>().ReverseMap();

            CreateMap<ReportDataVideoDaily, ReportDataVideoDailyDto>()
                .MapToBaseViewModel()
                .ReverseMap();
        }

        public void MappingFromResource()
        {

        }
    }

    public static class CommonMappings
    {
        public static IMappingExpression<TSource, TDestination> MapToBaseViewModel<TSource, TDestination>(this IMappingExpression<TSource, TDestination> map)
            where TDestination : BaseDto
        {
            return map
                .ForMember(dest => dest.CreatedByUserName, soucre => soucre.MapFrom("CreatedByUser.UserName"))
                .ForMember(dest => dest.UpdatedByUserName, soucre => soucre.MapFrom("UpdatedByUser.UserName"))
                .ForMember(dest => dest.UpdatedByUserName, soucre => soucre.MapFrom("DeletedByUser.UserName"));


            //else { return map; }
            ////return map
            //.ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom("CreatedByUserName"));

        }
    }
}
