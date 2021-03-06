
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.DTO
{
    public class ReservationDTO
    {
        public DateTime ReservationStart { get; set; }

        public DateTime ReservationEnd { get; set; }

        public int RatePlanId { get; set; }

        public int RoomId { get; set; }

        public int AmountOfAdults { get; set; }

        public int AmountOfChildren { get; set; }
        public int Price { get; internal set; }
    }
}
