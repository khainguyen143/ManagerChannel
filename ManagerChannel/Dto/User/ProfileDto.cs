using API.Models.Authorization;
using System.Collections.Generic;

namespace ManagerChannel.Dto.User
{
    public class ProfileDto
    {
    }

    public class UserRoleDto
    {
        public List<Permission> Permissions { get; set; }
    }
}
