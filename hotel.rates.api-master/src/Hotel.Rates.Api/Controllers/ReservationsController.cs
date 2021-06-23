using Hotel.Rates.Api.Models;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : BaseApiController
    {
        private readonly IReservationService reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationModel reservationModel)
        {
            var result = this.reservationService.CreateReservation(new Core.DTO.ReservationDTO
            {
                AmountOfAdults = reservationModel.AmountOfAdults,
                AmountOfChildren = reservationModel.AmountOfChildren,
                RatePlanId = reservationModel.RatePlanId,
                ReservationEnd = reservationModel.ReservationEnd,
                ReservationStart = reservationModel.ReservationStart,
                RoomId = reservationModel.RoomId,
            });
            return GetResult(result);
        }

    }
}
