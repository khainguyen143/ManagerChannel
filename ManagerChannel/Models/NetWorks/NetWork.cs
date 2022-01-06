using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Channels;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Models.Networks
{
    public class NetWork : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Name { get; set; }
        public string Note { get; set; }

        public List<NetworkHistory> NetWorkHistories { get; set; }
        //----------------------------------------
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string UpdatedByUserId { get; set; }
        public User UpdatedByUser { get; set; }
        public string DeletedByUserId { get; set; }
        public User DeletedByUser { get; set; }
    }
}
