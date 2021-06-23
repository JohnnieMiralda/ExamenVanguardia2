using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Entities
{
    public class NightlyRatePlan: RatePlan
    {
        public NightlyRatePlan()
        {
            RatePlanType = (int)Data.RatePlanType.Nightly;
        }

    }
}
