using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IQueueableJobModel : IJobModel
    {
        public DateTime? JobQueueTime { get; set; }  // thời gian bắt đầu xếp hàng => thằng nào xếp hàng trước cho chạy trước
    }
}
