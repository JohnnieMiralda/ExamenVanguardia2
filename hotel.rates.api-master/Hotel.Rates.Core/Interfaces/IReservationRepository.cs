using Hotel.Rates.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IReservationRepository
    {
        double addReservation(RoomDTO room);
    }
}
