using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IRatePlanRoomRepository roomRepository;
        private readonly IRatePlanRepository ratePlanRepository;
        private readonly IRepository<IntervalRatePlan, int> intervalRatePlanRepository;
        private readonly IRoomRepository roomsave;

        public ReservationService(
            IRatePlanRoomRepository roomRepository,
            IRatePlanRepository ratePlanRepository,
            IRepository<IntervalRatePlan, int> intervalRatePlanRepository,
            IRoomRepository roomsave
            )
        {
            this.roomRepository = roomRepository;
            this.ratePlanRepository = ratePlanRepository;
            this.intervalRatePlanRepository = intervalRatePlanRepository;
            this.roomsave= roomsave;
        }


        public ServiceResult<ReservationDTO> CreateReservation(ReservationDTO reservationModelDTO)
        {
            var ratePlan = this.ratePlanRepository.GetById(reservationModelDTO.RatePlanId);
            

            var season= ratePlan.Seasons
                .Any(s => s.StartDate <= reservationModelDTO.ReservationStart && s.EndDate >= reservationModelDTO.ReservationEnd);
            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservationModelDTO.RoomId && r.RatePlanId == reservationModelDTO.RatePlanId);
            var roomAvailable= room.Room.Amount > 0 &&
                room.Room.MaxAdults >= reservationModelDTO.AmountOfAdults &&
                room.Room.MaxChildren >= reservationModelDTO.AmountOfChildren;

            if (ratePlan == null)
            {
                return ServiceResult<ReservationDTO>.ErrorResult("No se encontro el plan solicitado");
            }
            if (room == null)
            {
                return ServiceResult<ReservationDTO>.ErrorResult("No hay cuartos disponible");
            }
            if (roomAvailable == false)
            {
                return ServiceResult<ReservationDTO>.ErrorResult("No hay cuartos disponible");
            }

            var days = (reservationModelDTO.ReservationEnd - reservationModelDTO.ReservationStart).TotalDays;
            IBaseRules[] validaciones =
            {
                new IntervalRules(ratePlanRepository),
                new NightlyRule(ratePlanRepository)
            };

            foreach (var validation in validaciones)
            {
                var val = validation.validRules(reservationModelDTO.RatePlanId,days);
                if (val != -1)
                {
                    roomsave.minusroom(room.Room.Amount);
                    return ServiceResult<ReservationDTO>.SuccessResult(new ReservationDTO { Price = (int)val });
                }
            }
            return ServiceResult<ReservationDTO>.ErrorResult("No se pudo hacer la reservacion.");
        }
    }
}
