using Hotel.Rates.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly InventoryContext inventoryContext;

        public RoomRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }

        public IReadOnlyList<Room> GetAll()
        {
            return this.inventoryContext.Rooms
                .Include(r => r.RatePlanRooms)
                .ToList();
        }

        public void minusroom(int r)
        {
            r -= 1;
            inventoryContext.SaveChanges();
        }
        
    }

}
