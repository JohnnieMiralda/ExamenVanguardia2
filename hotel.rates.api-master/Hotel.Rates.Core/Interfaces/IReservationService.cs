using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IReservationService
    {
        ServiceResult<ReservationDTO> CreateReservation(ReservationDTO reservationDTO);
    }
}
