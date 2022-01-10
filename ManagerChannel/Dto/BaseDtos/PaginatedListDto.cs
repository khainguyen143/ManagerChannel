using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerChannel.Dto.BaseDtos
{
    public class PaginatedListDto<TModel, TDto> where TDto : BaseDto where TModel : BaseModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int ItemsCount { get; set; }
        public int PagesCount { get; set; }
        public List<TDto> Items { get; set; }

        public PaginatedListDto(List<TDto> items, int itemsCount, int pagesCount, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            PageSize = pageSize;
            ItemsCount = itemsCount;
            PagesCount = pagesCount;
        }

        public static async Task<PaginatedListDto<TModel, TDto>> CreateAsync(IQueryable<TModel> query, int pageIndex, int pageSize, Func<TModel, TDto> convertEntityToDtoFunc)
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

            return new PaginatedListDto<TModel, TDto>(items, itemsCount, pageCount, pageIndex, pageSize);
        }

    }
}
