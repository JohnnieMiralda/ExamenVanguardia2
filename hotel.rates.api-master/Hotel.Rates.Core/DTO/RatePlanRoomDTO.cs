using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.DTO
{
    public class RatePlanRoomDTO
    {
        public int RatePlanId { get; set; }

        public RatePlan Rateplan { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
