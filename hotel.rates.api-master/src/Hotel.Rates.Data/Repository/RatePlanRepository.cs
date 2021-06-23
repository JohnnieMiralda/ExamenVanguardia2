using Hotel.Rates.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repository
{
    public class RatePlanRepository : IRatePlanRepository
    {
        private readonly InventoryContext context;

        public RatePlanRepository(InventoryContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<RatePlan> GetAll()
        {
            return this.context.RatePlans
                .Include(d => d.RatePlanRooms)
                .ThenInclude(dd => dd.Room)
                .Include(d => d.Seasons).ToList();
        }

        public RatePlan GetById(int id)
        {
            return this.context.RatePlans
                .Include(d => d.RatePlanRooms)
                .ThenInclude(dd => dd.Room)
                .Include(d => d.Seasons).FirstOrDefault(d => d.Id == id);
        }
    }

}
