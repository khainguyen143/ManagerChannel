using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class BaseDbJobDto : BaseDto
    {
        // Job status
        public JobState JobState { get; set; }
        public JobResult? JobResult { get; set; }
        public string JobMessage { get; set; }

        // Job executing time
        public DateTime? JobExecutingBeginTime { get; set; }
        public DateTime? JobExecutingEndTime { get; set; }

        public override void AsignBaseData<TModel>(TModel entity)
        {
            base.AsignBaseData(entity);
            if (typeof(IJobModel).IsAssignableFrom(typeof(TModel)))
            {
                JobState = ((IJobModel)entity).JobState;
                JobResult = ((IJobModel)entity).JobResult;
                JobMessage = ((IJobModel)entity).JobMessage;

                JobExecutingBeginTime = ((IJobModel)entity).JobExecutingBeginTime;
                JobExecutingEndTime = ((IJobModel)entity).JobExecutingEndTime;
            }
        }
    }

    public class BaseDbJobFilter : BaseFilterDto
    {
        /*
         * Thêm các sort by: JobState, JobResult, JobMessage, JobExecutingBeginTime, JobExecutingEndTime
         */

        // Job status
        public JobState? JobState { get; set; }
        public JobResult? JobResult { get; set; }
        public string JobMessage { get; set; }

        // Job executing time
        public DateTime? JobExecutingBeginTimeFrom { get; set; }
        public DateTime? JobExecutingBeginTimeTo { get; set; }
        public DateTime? JobExecutingEndTimeFrom { get; set; }
        public DateTime? JobExecutingEndTimeTo { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if(JobState != null && !Enum.IsDefined(typeof(JobState), JobState))
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào 'Trạng thái' không hợp lệ");
            }

            if (JobState != null && !Enum.IsDefined(typeof(JobState), JobState))
            {
                return new DtoValidationResult(false, @"Dữ liệu đầu vào 'kết quả' không hợp lệ");
            }

            return new DtoValidationResult(true);
        }

        public override IQueryable<T> CreateBaseQuery<T>(IQueryable<T> query)
        {
            query = base.CreateBaseQuery(query);

            if (typeof(IJobModel).IsAssignableFrom(typeof(T)))
            {
                if (JobState != null)
                {
                    query = query.Where(entity => ((IJobModel)entity).JobState == JobState);
                }
                if(JobResult != null)
                {
                    query = query.Where(entity => ((IJobModel)entity).JobResult == JobResult);
                }
                if (!string.IsNullOrEmpty(JobMessage))
                {
                    query = query.Where(entity => ((IJobModel)entity).JobMessage == JobMessage);
                }
                if(JobExecutingBeginTimeFrom != null)
                {
                    query = query.Where(entity => ((IJobModel)entity).JobExecutingBeginTime >= JobExecutingBeginTimeFrom);
                }
                if (JobExecutingBeginTimeTo != null)
                {
                    query = query.Where(entity => ((IJobModel)entity).JobExecutingBeginTime <= JobExecutingBeginTimeTo);
                }
                if (JobExecutingEndTimeFrom != null)
                {
                    query = query.Where(entity => ((IJobModel)entity).JobExecutingEndTime >= JobExecutingEndTimeFrom);
                }
                if (JobExecutingEndTimeTo != null)
                {
                    query = query.Where(entity => ((IJobModel)entity).JobExecutingEndTime <= JobExecutingEndTimeTo);
                }
            }

            return query;
        }
    }

    public class BaseAddDbJobDto : BaseAddDto
    {
        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            return new DtoValidationResult(true);
        }
    }

    public class BaseJobProcessingDto
    {
        public string Id { get; set; }

        public JobState JobState { get; set; }
        public JobResult? JobResult { get; set; }
        public string JobMessage { get; set; }

        public DateTime? JobExecutingBeginTime { get; set; }
        public DateTime? JobExecutingEndTime { get; set; }

        public int? JobProcessingPercentage { get; set; }
        public string JobProcessingMessage { get; set; }
    }
}
