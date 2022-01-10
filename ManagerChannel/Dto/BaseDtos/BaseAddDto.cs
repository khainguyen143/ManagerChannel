using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class BaseAddDto
    {
        public virtual DtoValidationResult Validate()
        {
            return new DtoValidationResult(true);
        }
    }
}
