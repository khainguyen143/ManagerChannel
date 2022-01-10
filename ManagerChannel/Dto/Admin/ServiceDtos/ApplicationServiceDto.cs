using API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Admin.ServiceDtos
{
    public class ApplicationServicesDto
    {
        public string ServiceNodeId { get; set; }
        public List<ApplicationServiceDto> Services { get; set; }
    }


    public class ApplicationServiceDto
    {
        public string ServiceName { get; set; }
        public ServiceState State { get; set; }
    }

    public class SedingEmailServiceDto
    {
        public string ServiceName { get; set; }
        public ServiceState State { get; set; }

        public int PendingJobsCount { get; set; }
        public int QueueingJobsCount { get; set; }
        public int SchedulingJobsCount { get; set; }
        public int ExecutingJobsCount { get; set; }
        public int StopRequestedJobsCount { get; set; }
        public int StoppingJobsCount { get; set; }
        public int CompletedJobsCount { get; set; }

        public int ErrorJobsCount { get; set; }
        public int WarningJobsCount { get; set; }
        public int SuccessJobsCount { get; set; }
    }

    public class PushingNotificationServiceDto
    {
        public string ServiceName { get; set; }
        public ServiceState State { get; set; }

        public int PendingJobsCount { get; set; }
        public int QueueingJobsCount { get; set; }
        public int SchedulingJobsCount { get; set; }
        public int ExecutingJobsCount { get; set; }
        public int StopRequestedJobsCount { get; set; }
        public int StoppingJobsCount { get; set; }
        public int CompletedJobsCount { get; set; }

        public int ErrorJobsCount { get; set; }
        public int WarningJobsCount { get; set; }
        public int SuccessJobsCount { get; set; }
    }
}
