using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Rules
{
    public class IntervalRules : IBaseRules
    {
        private readonly IRatePlanRepository ratePlanRepository;
        public IntervalRules(
                IRatePlanRepository ratePlanRepository
            )
        {
            this.ratePlanRepository = ratePlanRepository;
        }
        public double validRules(int id, double days)
        {
            var ratePlan = ratePlanRepository.GetById(id);

            if (ratePlan.RatePlanType == 2)
            {
                return (ratePlan.Price/days);
            }
            else
            {
                return -1;
            }
        }
    }
}
