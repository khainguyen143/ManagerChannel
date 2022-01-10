using ManagerChannel.Dto.BaseDtos;
using ManagerChannel.Dto.NetworksDto;
using System.Collections.Generic;

namespace ManagerChannel.Dto.PayDto
{
    public class PaymentAccountDto : BaseDto
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
