using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerChannel.Dto.BaseDtos
{
    public class BaseAddDto
    {
        public virtual DtoValidationResult Validate()
        {
            return new DtoValidationResult(true);
        }
    }
}
