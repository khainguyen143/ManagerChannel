using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerChannel.Dto.BaseDtos
{
    public class DtoValidationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public DtoValidationResult(bool isSuccess, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}
