using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IJobModel : ILockableModel
    {
        // Job status
        public JobState JobState { get; set; }
        public JobResult? JobResult { get; set; }
        public string JobMessage { get; set; }

        // Job executing time
        public DateTime? JobExecutingBeginTime { get; set; }
        public DateTime? JobExecutingEndTime { get; set; }

        /* 
         * Trong TH chạy nhiều service node cùng kết nối đến 1 db.
         * Mỗi service node cần một định danh id, và sau khi nhận job về queue, sẽ gán node id cho job, để biết job này đang được thực hiện bởi node nào.
         * 
         * Trong TH node đó bị crash/restart khi đang thực thi job thì trạng thái job sẽ là queueing/executing.
         * Sau khi node sống lại => cần load các job CỦA MÌNH (qua node id) mà thực thi dở để xử lý job. Nếu k trạng thái của nó sẽ executing mãi.
         */
        public string JobExecutingByServiceNodeId { get; set; }
    }

    public enum JobState
    {
        Pending = 0,        // not ready yet, waiting to user/system to put this job into queue
        Queueing = 1,       // ready to execute, waiting to service to execute => for quequeable job
        Scheduling = 2,     // ready to execute, waiting to service to execute => for schedulable job
        Executing = 3,      // executing by services
        RequestedToStop = 4,// was requested to stop by user, or timeout
        Stopping = 5,       // has been cacelled job by cancellation token, wating for task to stop
        Completed = 6       // completed
    }

    public enum JobResult
    {
        Error,
        Warning,
        Success
    }
}
