using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.Repository
{
    public class IntervalRatePlanRepository : IIntervalRatePlanRepository
    {
        private readonly InventoryContext inventoryContext;

        public IntervalRatePlanRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
    }

}
