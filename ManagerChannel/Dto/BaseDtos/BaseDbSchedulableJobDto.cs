using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.BaseDtos
{
    public class BaseDbSchedulableJobDto : BaseDbJobDto
    {
        public DateTime ScheduleTime { get; set; }

        public override void AsignBaseData<TModel>(TModel entity)
        {
            base.AsignBaseData(entity);
            if (typeof(ISchedulableJobModel).IsAssignableFrom(typeof(TModel)))
            {
                ScheduleTime = ((ISchedulableJobModel)entity).ScheduleTime;
            }
        }
    }

    public class BaseDbSchedulableJobFilter : BaseDbJobFilter
    {
        /*
         * Thêm các sort by: ScheduleTime
         */
        public DateTime? ScheduleTimeFrom { get; set; }
        public DateTime? ScheduleTimeTo { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            return new DtoValidationResult(true);
        }

        public override IQueryable<T> CreateBaseQuery<T>(IQueryable<T> query)
        {
            query = base.CreateBaseQuery(query);

            if (typeof(ISchedulableJobModel).IsAssignableFrom(typeof(T)))
            {
                if (ScheduleTimeFrom != null)
                {
                    query = query.Where(entity => ((ISchedulableJobModel)entity).ScheduleTime >= ScheduleTimeFrom);
                }
                if (ScheduleTimeTo != null)
                {
                    query = query.Where(entity => ((ISchedulableJobModel)entity).ScheduleTime <= ScheduleTimeTo);
                }
            }

            return query;
        }
    }

    public class BaseAddDbSchedulableJobDto : BaseAddDbJobDto
    {
        public DateTime ScheduleTime { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if (ScheduleTime < DateTime.Now.Subtract(TimeSpan.FromMinutes(1)))
            {
                return new DtoValidationResult(false, "Thời gian không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
