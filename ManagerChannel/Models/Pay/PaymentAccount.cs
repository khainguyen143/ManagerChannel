using API.Models;
using API.Models.Authorization;
using ManagerChannel.Models.Channels;
using ManagerChannel.Models.Networks;
using System;

namespace ManagerChannel.Models.Pay
{
    public class PaymentAccount : BaseModel, ILoggableUserActionModel, ISoftDeletableModel
    {
        public string Name { get; set; }
        public string Note { get; set; }
        
        //-----------------------------------------
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
