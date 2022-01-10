using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerChannel.Dto.BaseDtos
{
    public class BaseDeleteRangeDto
    {
        public List<string> Ids { get; set; }

        public virtual DtoValidationResult Validate()
        {
            if (Ids == null || Ids.Count == 0)
            {
                return new DtoValidationResult(false, "Danh sách Id không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
