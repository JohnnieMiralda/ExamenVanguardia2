using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.Repository
{
    public class RatePlanRoomRepository : IRatePlanRoomRepository
    {
        private readonly InventoryContext inventoryContext;

        public RatePlanRoomRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
    }

}
