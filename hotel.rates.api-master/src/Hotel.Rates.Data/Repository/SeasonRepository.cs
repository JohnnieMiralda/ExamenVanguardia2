using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.Repository
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly InventoryContext inventoryContext;

        public SeasonRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }
    }

}
