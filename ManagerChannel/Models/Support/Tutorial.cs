using API.Models.Authorization;
using System;

namespace API.Models.Support
{
    public class Tutorial : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }

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
