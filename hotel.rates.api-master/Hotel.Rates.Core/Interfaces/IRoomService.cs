using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRoomService
    {
        ServiceResult<IReadOnlyList<RoomDTO>> GetRooms();
    }
}
