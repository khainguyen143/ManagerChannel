using API.Dto;
using ManagerChannel.Dto.NetworksDto;
using System.Collections.Generic;

namespace ManagerChannel.Dto.PayDto
{
    public class PaymentAccount : BaseDto
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
