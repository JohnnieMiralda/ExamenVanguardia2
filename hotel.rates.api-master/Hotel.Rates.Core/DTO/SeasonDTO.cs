using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.DTO
{
    public class SeasonDTO
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RatePlanDTO RatePlan { get; set; }

        public int RatePlanId { get; set; }
    }
}
