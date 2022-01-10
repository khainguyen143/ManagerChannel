using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Admin.Authorization
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleFilterDto : BaseFilterDto
    {
        /*
         * Order by: Name, Description
         */

        public string Name { get; set; }
        public string Description { get; set; }

        public override DtoValidationResult Validate()
        {
            return base.Validate();
        }
    }

    public class AddRoleDto : BaseAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseValidateResult = base.Validate();
            if (!baseValidateResult.IsSuccess)
            {
                return baseValidateResult;
            }

            if (string.IsNullOrEmpty(Name?.Trim()))
            {
                return new DtoValidationResult(false, "Tên không hơp lệ");
            }

            return new DtoValidationResult(true);
        }
    }

    public class EditRoleDto : BaseEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseValidateResult = base.Validate();
            if (!baseValidateResult.IsSuccess)
            {
                return baseValidateResult;
            }

            if (string.IsNullOrEmpty(Name?.Trim()))
            {
                return new DtoValidationResult(false, "Tên không hơp lệ");
            }

            return new DtoValidationResult(true);
        }
    }

    public class DeleteRangeRoleDto : BaseDeleteRangeDto
    {
        public override DtoValidationResult Validate()
        {
            return base.Validate();
        }
    }

    public class EditRolePermissionDto
    {
        public string RoleId { get; set; }
        public List<Permission> Permissions { get; set; }

        public DtoValidationResult Validate()
        {
            if (string.IsNullOrEmpty(RoleId?.Trim()) || Permissions == null)
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hơp lệ");
            }

            if (Permissions.Any(p => !Enum.IsDefined(typeof(Permission), p)))
            {
                return new DtoValidationResult(false, "Danh sách quyền không hơp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
