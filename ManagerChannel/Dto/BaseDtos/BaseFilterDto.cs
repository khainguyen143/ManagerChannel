using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using API.Models;
using ManagerChannel;
using ManagerChannel.Interfaces;

namespace ManagerChannel.Dto.BaseDtos
{
    public class BaseFilterDto
    {
        // PAGINATION
        public int PageIndex { get; set; }
        public int PageSize { get; set; }   // accept only 10, 25, 50, 100, 200

        // SORTS
        public string OrderBy { get; set; } // property name
        public bool OrderByDesc { get; set; }

        // FILTERS
        public string Ids { get; set; } // seperated by comma

        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        public string CreatedByUserIds { get; set; }    // seperated by comma
        public string CreatedByUserNames { get; set; }    // seperated by comma

        public DateTime? UpdatedDateFrom { get; set; }
        public DateTime? UpdatedDateTo { get; set; }
        public string UpdatedByUserIds { get; set; }    // seperated by comma
        public string UpdatedByUserNames { get; set; }    // seperated by comma

        /// <summary>
        /// Create sorts and base filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual IQueryable<T> CreateBaseQuery<T>(IQueryable<T> query) where T : BaseModel
        {
            try
            {
                // sort
                if (!string.IsNullOrEmpty(OrderBy))
                {
                    if (typeof(T).GetProperty(OrderBy) != null)
                    {
                        if (!OrderByDesc)
                        {
                            query = query.OrderBy(OrderBy);
                        }
                        else
                        {
                            query = query.OrderByDescending(OrderBy);
                        }
                    }

                    if (typeof(ILoggableUserActionModel).IsAssignableFrom(typeof(T)))
                    {
                        if (OrderBy == "CreatedByUserName")
                        {
                            if (!OrderByDesc)
                            {
                                query = query.OrderBy(entity => ((ILoggableUserActionModel)entity).CreatedByUser.UserName);
                            }
                            else
                            {
                                query = query.OrderByDescending(entity => ((ILoggableUserActionModel)entity).CreatedByUser.UserName);
                            }
                        }
                        if (OrderBy == "UpdatedByUserName")
                        {
                            if (!OrderByDesc)
                            {
                                query = query.OrderBy(entity => ((ILoggableUserActionModel)entity).UpdatedByUser.UserName);
                            }
                            else
                            {
                                query = query.OrderByDescending(entity => ((ILoggableUserActionModel)entity).UpdatedByUser.UserName);
                            }
                        }
                    }
                }

                // filter
                if (!string.IsNullOrEmpty(Ids))
                {
                    var ids = Ids.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim());
                    query = query.Where(e => ids.Contains(e.Id));
                }

                if (!string.IsNullOrEmpty(CreatedByUserIds) && typeof(ILoggableUserActionModel).IsAssignableFrom(typeof(T)))
                {
                    var ids = CreatedByUserIds.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim());
                    query = query.Where(e => !string.IsNullOrEmpty(((ILoggableUserActionModel)e).CreatedByUserId) && ids.Contains(((ILoggableUserActionModel)e).CreatedByUserId));
                }
                if (!string.IsNullOrEmpty(CreatedByUserNames) && typeof(ILoggableUserActionModel).IsAssignableFrom(typeof(T)))
                {
                    var userNames = CreatedByUserNames.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim());
                    query = query.Where(e => userNames.Contains(((ILoggableUserActionModel)e).CreatedByUser.UserName));
                }

                if (!string.IsNullOrEmpty(UpdatedByUserIds))
                {
                    var ids = UpdatedByUserIds.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim());
                    query = query.Where(e => !string.IsNullOrEmpty(((ILoggableUserActionModel)e).UpdatedByUserId) && ids.Contains(((ILoggableUserActionModel)e).UpdatedByUserId));
                }
                if (!string.IsNullOrEmpty(UpdatedByUserNames))
                {
                    var userNames = UpdatedByUserNames.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim());
                    query = query.Where(e => userNames.Contains(((ILoggableUserActionModel)e).UpdatedByUser.UserName));
                }

                if (CreatedDateFrom != null)
                {
                    query = query.Where(e => e.CreatedDate >= CreatedDateFrom);
                }
                if (CreatedDateTo != null)
                {
                    query = query.Where(e => e.CreatedDate <= CreatedDateTo);
                }
                if (UpdatedDateFrom != null)
                {
                    query = query.Where(e => e.UpdatedDate >= UpdatedDateFrom);
                }
                if (UpdatedDateTo != null)
                {
                    query = query.Where(e => e.UpdatedDate <= UpdatedDateTo);
                }

                return query;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last());
                throw;
            }

        }

        public virtual DtoValidationResult Validate()
        {
            if (PageIndex < 1)
            {
                return new DtoValidationResult(false, "Chỉ số trang không hợp lệ");
            }

            if (PageSize < 1)
            {
                return new DtoValidationResult(false, "Số mục mỗi trang không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
