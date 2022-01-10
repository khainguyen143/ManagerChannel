using ManagerChannel.Dto.BaseDtos;
using ManagerChannel.Interfaces;
using ManagerChannel.Models.Teams;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagerChannel.Dto.TeamDtos
{
    public class TeamDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        // team hierarchical
        public string ParentTeamId { get; set; }
    }
   

    public class AddTeamDto : BaseAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        // team hierarchical
        public string ParentTeamId { get; set; }

        public virtual DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if(string.IsNullOrEmpty(Name))
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }
            if(string.IsNullOrEmpty(Description))
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }
            if (string.IsNullOrEmpty(Note))
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }
            if (string.IsNullOrEmpty(ParentTeamId))
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }
            return new DtoValidationResult(true);
        }
    }

    public class FilterTeamDto : BaseFilterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        // team hierarchical
        public string ParentTeamId { get; set; }
        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }
            return new DtoValidationResult(true);
        }

        public virtual IQueryable<T> CreateBaseQuery<T>(IQueryable<T> query) where T : Team
        {
            try
            {
                query = base.CreateBaseQuery(query);

                if(string.IsNullOrEmpty(Name))
                {
                    query = query.Where(x => Name.Contains(x.Name));
                }    
                if(string.IsNullOrEmpty(Description))
                {
                    query = query.Where(x => Description.Contains(x.Description));
                }
                if (string.IsNullOrEmpty(Note))
                {
                    query = query.Where(x => Note.Contains(x.Note));
                }
                if (string.IsNullOrEmpty(ParentTeamId))
                {
                    query = query.Where(x => ParentTeamId.Contains(x.ParentTeamId));
                }
                return query;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

    public class EditTeamDto : BaseEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string ParentTeamId { get; set; }
    }

    public class UserRoleInTeamDto : BaseDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string TeamId { get; set; }
    }

    public class RoleInTeamDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RolePermissionInTeamDto : BaseDto
    {
        public string RoleId { get; set; }

        public TeamPermission Permission { get; set; }
    }
}
