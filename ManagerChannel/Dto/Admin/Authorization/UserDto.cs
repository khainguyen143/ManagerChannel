using API.Constants;
using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Admin.Authorization
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public List<RoleDto> Roles { get; set; }
        public List<PermissionDetail> Permissions { get; set; }
        public List<PermissionDetail> Restrictions { get; set; }
    }

    public class FilterUserDto : BaseFilterDto
    {
        /*
         * Order by: UserName, RolesCount, PermissionsCount, RestrictionsCount
         */

        public string UserName { get; set; }
        public List<string> RoleIds { get; set; }
        public List<Permission> Permissions { get; set; }
        public List<Permission> Restrictions { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if (Permissions != null && Permissions.Any(p => !Enum.IsDefined(typeof(Permission), p)))
            {
                return new DtoValidationResult(false, "Danh sách quyền không hơp lệ");
            }

            if (Restrictions != null && Restrictions.Any(p => !Enum.IsDefined(typeof(Permission), p)))
            {
                return new DtoValidationResult(false, "Danh sách quyền hạn chế không hơp lệ");
            }

            return new DtoValidationResult(true);
        }
    }

    public class AddUserDto : BaseAddDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if(string.IsNullOrEmpty(UserId?.Trim()) || string.IsNullOrEmpty(UserName?.Trim()))
            {
                return new DtoValidationResult(false, "Yêu cầu tên đăng nhập và id người dùng");
            }

            return new DtoValidationResult(true);
        }
    }

    public class EditUserRoleDto
    {
        public string UserId { get; set; }
        public List<string> RoleIds { get; set; }

        public DtoValidationResult Validate()
        {
            if (string.IsNullOrEmpty(UserId) || RoleIds == null)
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }
            return new DtoValidationResult(true);
        }
    }

    public class EditUserRestrictionDto
    {
        public string UserId { get; set; }
        public List<Permission> Permissions { get; set; }

        public DtoValidationResult Validate()
        {
            if (string.IsNullOrEmpty(UserId) || Permissions == null)
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }

            if(Permissions.Any(p => !Enum.IsDefined(typeof(Permission), p)))
            {
                return new DtoValidationResult(false, "Danh sách quyền bị hạn chế không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
