using API.Models.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Notifications
{
    public class Notification : BaseModel, ISoftDeletableModel, ILoggableUserActionModel
    {
        public string NotifyToUserId { get; set; }
        public User NotifyToUser { get; set; }

        public bool IsUserRead { get; set; }
        public DateTime? UserReadTime { get; set; }

        public NotificationType NotificationType { get; set; }
        public string NotificationContent { get; set; }
        public string NotificationUrl { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public enum NotificationType
    {
        None
    }
}
