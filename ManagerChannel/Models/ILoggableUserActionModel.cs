using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface ILoggableUserActionModel
    {
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }

        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

    }
}
