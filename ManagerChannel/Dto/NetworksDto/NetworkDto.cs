using ManagerChannel.Dto.BaseDtos;
using ManagerChannel.Dto.ChannelDto;
using System;
using System.Collections.Generic;

namespace ManagerChannel.Dto.NetworksDto
{
    public class NetworkDto : BaseDto
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }

    public class Network_PaymentAccountDto : BaseDto
    {
        public string PaymentAccountId { get; set; }
        public string NetworkId { set; get; }
        public float NetworkRate { get; set; }
    }

    public class Network_UserRoleInTeamDto
    {
        public string UserRoleInTeamId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
