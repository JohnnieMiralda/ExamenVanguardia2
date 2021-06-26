using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Hotel.Rates.Data;
using System.Linq;

namespace Hotel.Rates.Core.Services
{
    public class RatePlanService : IRatePlanService
    {
        private readonly IRatePlanRepository ratePlanRepositoryBase;

        public RatePlanService(IRatePlanRepository ratePlanRepositoryBase)
        {
            this.ratePlanRepositoryBase = ratePlanRepositoryBase;
        }

        public ServiceResult<IReadOnlyList<RatePlanDTO>> GetAll()
        {
            var rates = this.ratePlanRepositoryBase.GetAll()
                .Select(d => new RatePlanDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Price = d.Price,
                    RatePlanType = d.RatePlanType,
                    RatePlanRooms = d.RatePlanRooms.Select(r => new RoomDTO
                    {
                        Amount = r.Room.Amount,
                        MaxAdults = r.Room.MaxAdults,
                        MaxChildren = r.Room.MaxChildren,
                        Name = r.Room.Name,

                    }).ToList(),
                    Seasons = d.Seasons.Select(s => new SeasonDTO
                    {
                        Id = s.Id,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                    }).ToList(),
                });

            return ServiceResult<IReadOnlyList<RatePlanDTO>>.SuccessResult(rates.ToList());


        }
        public ServiceResult<RatePlanDTO> GetRatePlansById(int id)
        {
            var result = this.ratePlanRepositoryBase.GetById(id);

            if (result == null)
            {
                return ServiceResult<RatePlanDTO>.ErrorResult($"Not found a result with Id [{id}]");
            }

            var resultRate = new RatePlanDTO
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
                RatePlanType = result.RatePlanType,
                RatePlanRooms = result.RatePlanRooms.Select(r => new RoomDTO
                {
                    Amount = r.Room.Amount,
                    MaxAdults = r.Room.MaxAdults,
                    MaxChildren = r.Room.MaxChildren,
                    Name = r.Room.Name,

                }).ToList(),
                Seasons = result.Seasons.Select(s => new SeasonDTO
                {
                    Id = s.Id,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                }).ToList(),
            };

            return ServiceResult<RatePlanDTO>.OkResult(resultRate);
        }
    }
}
