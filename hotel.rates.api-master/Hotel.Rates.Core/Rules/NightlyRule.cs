using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Rules
{
    public class NightlyRule : IBaseRules
    {
        private readonly IRatePlanRepository ratePlanRepository;
        public NightlyRule(
            IRatePlanRepository ratePlanRepository
            )
        {
            this.ratePlanRepository = ratePlanRepository;
        }
        public double validRules(int id , double days)
        {
            var ratePlan = ratePlanRepository.GetById(id);

            if (ratePlan.RatePlanType== 1)
            {
                return (days * ratePlan.Price);
            }
            else
            {
                return -1;
            }
        }
    }
}
