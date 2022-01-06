using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface ISchedulableJobModel : IJobModel
    {
        public DateTime ScheduleTime { get; set; }
    }
}
