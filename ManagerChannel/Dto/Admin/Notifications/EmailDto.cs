using API.Dto.BaseDtos;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Admin.Notifications
{
    public class SendingEmailDto : BaseDbSchedulableJobDto
    {
        public string ToAddresses { get; set; }
        public string ToCcAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class SendingEmailFilterDto : BaseDbSchedulableJobFilter
    {
        /*
         * Thêm các sort by: ToAddresses, ToCcAddresses, Subject, Bod
         */

        public string ToAddresses { get; set; }     // splited by comma ,
        public string ToCcAddresses { get; set; }   // splited by comma ,
        public string Subject { get; set; }
        public string Body { get; set; }

        public override DtoValidationResult Validate()
        {
            return base.Validate();
        }
    }

    public class AddSendingEmailDto : BaseAddDbSchedulableJobDto
    {
        public List<string> ToAddresses { get; set; }

        public string ToCcAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public override DtoValidationResult Validate()
        {
            var baseResult = base.Validate();
            if (!baseResult.IsSuccess)
            {
                return baseResult;
            }

            if (ToAddresses == null || ToAddresses.Count == 0)
            {
                return new DtoValidationResult(false, "Không có địa chỉ nhận Email");
            }

            if (string.IsNullOrEmpty(Subject?.Trim()))
            {
                return new DtoValidationResult(false, "Không có tiêu đề Email");
            }

            if (string.IsNullOrEmpty(Body?.Trim()))
            {
                return new DtoValidationResult(false, "Không có nội dung Email");
            }

            return new DtoValidationResult(true);
        }
    }

    public class ReScheduleSedingEmailDto
    {
        public List<string> Ids { get; set; }
        public DateTime ScheduleTime { get; set; }

        public DtoValidationResult Validate()
        {
            if(Ids == null || Ids.Count == 0)
            {
                return new DtoValidationResult(false, "Danh sách email không hợp lệ");
            }

            if (ScheduleTime < DateTime.Now.Subtract(TimeSpan.FromMinutes(1)))
            {
                return new DtoValidationResult(false, "Thời gian không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }

    public class CancelSedingEmailDto
    {
        public List<string> Ids { get; set; }

        public DtoValidationResult Validate()
        {
            if (Ids == null || Ids.Count == 0)
            {
                return new DtoValidationResult(false, "Danh sách email không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
