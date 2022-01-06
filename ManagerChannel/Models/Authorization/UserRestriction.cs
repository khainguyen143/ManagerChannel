using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Authorization
{
    public class UserRestriction : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        public Permission Permission { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
