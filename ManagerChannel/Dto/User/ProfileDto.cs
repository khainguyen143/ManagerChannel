using API.Models.Authorization;
using System.Collections.Generic;

namespace API.Dto.User
{
    public class ProfileDto
    {
    }

    public class UserRoleDto
    { 
        public List<Permission> Permissions { get; set; }
    }
}
