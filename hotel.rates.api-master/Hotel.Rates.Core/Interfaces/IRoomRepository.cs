using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRoomRepository
    {
        IReadOnlyList<Room> GetAll();
    }

}
