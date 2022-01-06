using API.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Notifications
{
    public class SendingEmailJob : BaseModel, ISoftDeletableModel, ILoggableUserActionModel, ISchedulableJobModel
    {
        public string ToAddresses { get; set; }
        public string ToCcAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public JobState JobState { get; set; }
        public JobResult? JobResult { get; set; }
        public string JobMessage { get; set; }
        public DateTime ScheduleTime { get; set; }
        public string JobExecutingByServiceNodeId { get; set; }
        public DateTime? JobExecutingBeginTime { get; set; }
        public DateTime? JobExecutingEndTime { get; set; }
        public bool IsLocked { get; set; }

        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public SendingEmailJob(string toAddresses, string toCcAddresses, string subject, string body, DateTime scheduleTime)
        {
            ToAddresses = toAddresses;
            ToCcAddresses = toCcAddresses;
            Subject = subject;
            Body = body;
            ScheduleTime = scheduleTime;

            JobState = JobState.Scheduling;
        }
    }
}
