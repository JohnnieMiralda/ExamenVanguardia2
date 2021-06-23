using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public ServiceResult<IReadOnlyList<RoomDTO>> GetRooms()
        {
            var rooms = this.roomRepository.GetAll()
                .Select(r => new RoomDTO
                {
                    Amount = r.Amount,
                    MaxAdults = r.MaxAdults,
                    MaxChildren = r.MaxChildren,
                    Name = r.Name,
                });

            return ServiceResult<IReadOnlyList<RoomDTO>>.SuccessResult(rooms.ToList());
        }
    }

}
