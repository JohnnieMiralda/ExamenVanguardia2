using Hotel.Rates.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data
{
    public abstract class RatePlan : BaseEntity<int>
    {
        public RatePlan()
        {
            Seasons = new List<Season>();
            RatePlanRooms = new List<RatePlanRoom>();
        }

        public string Name { get; set; }

        public int RatePlanType { get; set; }

        public double Price { get; set; }

        public ICollection<Season> Seasons { get; set; }

        public ICollection<RatePlanRoom> RatePlanRooms { get; set; }
    }

}
