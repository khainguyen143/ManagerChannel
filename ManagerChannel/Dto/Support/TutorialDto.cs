using API.Models.Support;
using ManagerChannel;
using ManagerChannel.Dto.BaseDtos;
using ManagerChannel.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagerChannel.Dto.Support
{
    public class TutorialDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }
        public void AsignBaseData(Tutorial entity)
        {
            base.AsignBaseData(entity);
            Title = entity.Title;
            URL = entity.URL;
            Content = entity.Content;
        }
    }

    public class TutorialsDto : BaseDto
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public void AsignBaseData(Tutorial entity)
        {
            base.AsignBaseData(entity);
            Title = entity.Title;
            URL = entity.URL;
        }

    }

    public class TutorialFilterDto : BaseFilterDto
    {
        public string Keyword { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }

        public virtual IQueryable<T> CreateBaseQuery<T>(IQueryable<T> query) where T : Tutorial
        {
            try
            {
                query = base.CreateBaseQuery(query);

                return query;
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last());
                throw;
            }

        }
    }
    public class TutorialAddDto : BaseAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }
        public virtual DtoValidationResult Validate()
        {
            var baseResult = base.Validate();

            if (string.IsNullOrEmpty(Title))
            {
                return new DtoValidationResult(false, "Chưa có Title");
            }
            if (string.IsNullOrEmpty(Content))
            {
                return new DtoValidationResult(false, "Chưa có Content");
            }
            if (string.IsNullOrEmpty(URL))
            {
                return new DtoValidationResult(false, "Chưa có URL");
            }

            return new DtoValidationResult(true);
        }
    }

    public class TutorialEditDto : BaseEditDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }
        public virtual DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            return new DtoValidationResult(true);
        }
    }

    public class TutorialDeleteRangeDto : BaseDeleteRangeDto
    {
        public override DtoValidationResult Validate()
        {
            return base.Validate();
        }
    }
}
