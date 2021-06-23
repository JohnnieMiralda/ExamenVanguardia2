using Hotel.Rates.Core.DTO;
using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core
{
    public class IntervalRatePlan : RatePlan
    {
        public IntervalRatePlan()
        {
            RatePlanType = (int) Data.RatePlanType.Interval;
        }

        public int IntervalLength { get; set; }
    }
}
