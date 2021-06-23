using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IRepository<RatePlan, int> repository;
        private readonly IRatePlanRoomRepository roomRepository;
        private readonly IRatePlanRepository ratePlanRepository;
        private readonly IRepository<IntervalRatePlan, int> intervalRatePlanRepository;

        public ReservationService(
            IRepository<RatePlan, int> repository,
            IRatePlanRoomRepository roomRepository,
            IRatePlanRepository ratePlanRepository,
            IRepository<IntervalRatePlan, int> intervalRatePlanRepository)
        {
            this.repository = repository;
            this.roomRepository = roomRepository;
            this.ratePlanRepository = ratePlanRepository;
            this.intervalRatePlanRepository = intervalRatePlanRepository;
        }


        public ServiceResult<ReservationDTO> CreateReservation(ReservationDTO reservationModelDTO)
        {
            var ratePlan = this.repository.GetById(reservationModelDTO.RatePlanId);
            if (ratePlan == null)
            {
                return ServiceResult<ReservationDTO>.ErrorResult("No se encontro el plan solicitado");
            }


            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservationModelDTO.RoomId && r.RatePlanId == reservationModelDTO.RatePlanId);

            room.Room.Amount -= 1;
            //this.roomRepository.Update(room);

            return ServiceResult<ReservationDTO>.SuccessResult(new ReservationDTO { Price = 10 });
        }

        private double ApplyRules(ReservationDTO reservationModelDTO, RatePlan ratePlan)
        {
            if (ratePlan != null)
            {
                //foreach (var rule in rules)
                //{
                //   if (rule.Applies(ratePlan))
                //    {
                //       
                //    }
                //}
            }
            return -1;
        }

    }
}
