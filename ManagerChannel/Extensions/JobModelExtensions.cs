/*using API.Data;
using API.Exceptions;
using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class JobModelExtensions
    {
        public static async Task<int> StartQueueing(this IQueueableJobModel model, ApplicationDbContext context)
        {
            try
            {
                if (model.IsLocked)
                {
                    throw new ModifyLockedEntityException();
                }

                // job đang chờ người dùng ra lệnh xếp hàng
                if (model.JobState == JobState.Pending)
                {
                    QueueJob(model);
                    return await context.SaveChangesAsync();
                }

                // job chưa kịp chạy thì đã bị dừng, giờ yêu cầu chạy lại
                if (model.JobState == JobState.Completed && model.JobResult == null)
                {
                    QueueJob(model);
                    return await context.SaveChangesAsync();
                }

                // job chạy lỗi, giờ yêu cầu chạy lại
                if (model.JobState == JobState.Completed && model.JobResult == JobResult.Error)
                {
                    QueueJob(model);
                    return await context.SaveChangesAsync();
                }

                return 0;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

        public static async Task<int> StartQueueing(this IEnumerable<IQueueableJobModel> models, ApplicationDbContext context)
        {
            try
            {
                foreach (var model in models)
                {
                    if (model.IsLocked)
                    {
                        continue;
                    }

                    // job đang chờ người dùng ra lệnh xếp hàng
                    if (model.JobState == JobState.Pending)
                    {
                        QueueJob(model);
                        continue;
                    }

                    // job chưa kịp chạy thì đã bị dừng, giờ yêu cầu chạy lại
                    if (model.JobState == JobState.Completed && model.JobResult == null)
                    {
                        QueueJob(model);
                        continue;
                    }

                    // job chạy lỗi, giờ yêu cầu chạy lại
                    if (model.JobState == JobState.Completed && model.JobResult == JobResult.Error)
                    {
                        QueueJob(model);
                        continue;
                    }
                }

                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

        public static async Task<int> ReSchedule(this ISchedulableJobModel model, DateTime scheduleTime, ApplicationDbContext context)
        {
            try
            {
                if (model.IsLocked)
                {
                    throw new ModifyLockedEntityException();
                }

                // job đang chờ người dùng ra lệnh xếp hàng
                if (model.JobState == JobState.Pending)
                {
                    ReScheduleJob(model, scheduleTime);
                    return await context.SaveChangesAsync();
                }

                // job chưa kịp chạy thì đã bị dừng, giờ yêu cầu chạy lại
                if (model.JobState == JobState.Completed && model.JobResult == null)
                {
                    ReScheduleJob(model, scheduleTime);
                    return await context.SaveChangesAsync();
                }

                // job chạy lỗi, giờ yêu cầu chạy lại
                if (model.JobState == JobState.Completed && model.JobResult == JobResult.Error)
                {
                    ReScheduleJob(model, scheduleTime);
                    return await context.SaveChangesAsync();
                }

                return 0;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

        public static async Task<int> ReSchedule(this IEnumerable<ISchedulableJobModel> models, DateTime scheduleTime, ApplicationDbContext context)
        {
            try
            {
                foreach (var model in models)
                {
                    if (model.IsLocked)
                    {
                        continue;
                    }

                    // job đang chờ người dùng ra lệnh xếp hàng
                    if (model.JobState == JobState.Pending)
                    {
                        ReScheduleJob(model, scheduleTime);
                        continue;
                    }

                    // job chưa kịp chạy thì đã bị dừng, giờ yêu cầu chạy lại
                    if (model.JobState == JobState.Completed && model.JobResult == null)
                    {
                        ReScheduleJob(model, scheduleTime);
                        continue;
                    }

                    // job chạy lỗi, giờ yêu cầu chạy lại
                    if (model.JobState == JobState.Completed && model.JobResult == JobResult.Error)
                    {
                        ReScheduleJob(model, scheduleTime);
                        continue;
                    }
                }

                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

        public static async Task<int> RequestToStopAsync(this IJobModel model, ApplicationDbContext context)
        {
            try
            {
                // job chưa kịp chạy thì đã bị dừng
                if (model.JobState == JobState.Queueing || model.JobState == JobState.Scheduling)
                {
                    model.JobState = JobState.Completed;
                    return await context.SaveChangesAsync();
                }

                // job đang chạy
                if (model.JobState == JobState.Executing)
                {
                    // unlock và set state
                    model.IsLocked = false;
                    model.JobState = JobState.RequestedToStop;
                    var changeCount = await context.SaveChangesAsync();
                    if (changeCount > 0)
                    {
                        // lock lại
                        model.IsLocked = true;
                        await context.SaveChangesAsync();
                    }

                    return changeCount;
                }

                return 0;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

        public static async Task<int> RequestToStopAsync(this IEnumerable<IJobModel> models, ApplicationDbContext context)
        {
            try
            {
                // job chưa kịp chạy thì đã bị dừng
                foreach (var model in models.Where(model => model.JobState == JobState.Queueing || model.JobState == JobState.Scheduling))
                {
                    model.JobState = JobState.Completed;
                }

                // job đang chạy
                // unlock và set state
                var executingModels = models.Where(model => model.JobState == JobState.Executing);
                foreach (var model in executingModels)
                {
                    model.IsLocked = false;
                    model.JobState = JobState.RequestedToStop;
                }

                var changeCount = await context.SaveChangesAsync();

                // lock lại
                if (executingModels.Count() != 0)
                {
                    foreach (var model in executingModels)
                    {
                        model.IsLocked = true;
                    }
                }
                await context.SaveChangesAsync();

                return changeCount;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                throw;
            }
        }

        private static void QueueJob(IQueueableJobModel model)
        {
            model.JobState = JobState.Queueing;
            model.JobResult = null;
            model.JobMessage = "";

            model.JobQueueTime = DateTime.Now;
            model.JobExecutingBeginTime = null;
            model.JobExecutingEndTime = null;
            model.JobExecutingByServiceNodeId = null;
        }

        private static void ReScheduleJob(ISchedulableJobModel model, DateTime scheduleTime)
        {
            model.JobState = JobState.Scheduling;
            model.ScheduleTime = scheduleTime;
            model.JobResult = null;
            model.JobMessage = "";

            model.JobExecutingBeginTime = null;
            model.JobExecutingEndTime = null;
            model.JobExecutingByServiceNodeId = null;
        }
    }
}
*/