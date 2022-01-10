using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerChannel.Dto.BaseDtos
{
    public class BaseEditDto
    {
        public string Id { get; set; }

        public virtual DtoValidationResult Validate()
        {
            if (string.IsNullOrEmpty(Id))
            {
                return new DtoValidationResult(false, "Dữ liệu đầu vào không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
