using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class BaseDto
    {
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserId { get; set; }
        public string UpdatedByUserName { get; set; }

        public virtual void AsignBaseData<TModel>(TModel entity) where TModel : BaseModel
        {
            Id = entity.Id;
            CreatedDate = entity.CreatedDate;
            UpdatedDate = entity.UpdatedDate;

            if(entity is ILoggableUserActionModel)
            {
                CreatedByUserId = ((ILoggableUserActionModel)entity).CreatedByUserId;
                CreatedByUserName = ((ILoggableUserActionModel)entity).CreatedByUser?.UserName;
                UpdatedByUserId = ((ILoggableUserActionModel)entity).UpdatedByUserId;
                UpdatedByUserName = ((ILoggableUserActionModel)entity).UpdatedByUser?.UserName;
            }
        }
    }
}
