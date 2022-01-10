using API.Dto.Admin.Authorization;
using API.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Admin.Notifications
{
    public class NotificationDto : BaseDto
    {
        public string NotifyToUserId { get; set; }
        public string NotifyToUserName { get; set; }

        public bool IsUserRead { get; set; }
        public DateTime? UserReadTime { get; set; }

        public NotificationType NotificationType { get; set; }
        public string NotificationContent { get; set; }
        public string NotificationUrl { get; set; }
    }

    public class NotificationFilterDto : BaseFilterDto
    {
        /*
         * Order by: NotifyToUserName, IsUserRead, UserReadTime, NotificationType
         */
        public List<string> NotifyToUserIds { get; set; }
        public bool? IsUserRead { get; set; }
        public NotificationType? NotificationType { get; set; }
        public string NotificationContent { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if(NotificationType != null && !Enum.IsDefined(typeof(NotificationType), NotificationType))
            {
                return new DtoValidationResult(false, "Loại thông báo không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }

    public class AddNotificationDto : BaseAddDto
    {
        public List<string> NotifyToUserIds { get; set; }

        public NotificationType NotificationType { get; set; }
        public string NotificationContent { get; set; }
        public string NotificationUrl { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if (NotifyToUserIds == null || NotifyToUserIds.Count == 0)
            {
                return new DtoValidationResult(false, "Không có người nhận thông báo");
            }

            if (!Enum.IsDefined(typeof(NotificationType), NotificationType))
            {
                return new DtoValidationResult(false, "Loại thông báo không hợp lệ");
            }

            if (string.IsNullOrEmpty(NotificationContent?.Trim()))
            {
                return new DtoValidationResult(false, "Không có nội dung thông báo");
            }

            return new DtoValidationResult(true);
        }
    }

    public class NotificationPaginatedListDto<TModel, TDto>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int ItemsCount { get; set; }
        public int PagesCount { get; set; }
        public int UnreadCount { get; set; }
        public List<TDto> Items { get; set; }


        public NotificationPaginatedListDto(List<TDto> items, int itemsCount, int pagesCount, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            PageSize = pageSize;
            ItemsCount = itemsCount;
            PagesCount = pagesCount;
        }

        public static async Task<NotificationPaginatedListDto<TModel, TDto>> CreateAsync(IQueryable<TModel> query, int pageIndex, int pageSize, Func<TModel, TDto> convertEntityToDtoFunc)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize > 200)
            {
                pageSize = 200;
            }
            if (pageSize < 10)
            {
                pageSize = 10;
            }

            var itemsCount = await query.CountAsync();
            var pageCount = (int)Math.Ceiling(itemsCount / (double)pageSize);
            if (pageCount < 1)
            {
                pageCount = 1;
            }
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }

            var items = (await query.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync()).Select(i => convertEntityToDtoFunc(i)).ToList();

            return new NotificationPaginatedListDto<TModel, TDto>(items, itemsCount, pageCount, pageIndex, pageSize);
        }
    }

}
