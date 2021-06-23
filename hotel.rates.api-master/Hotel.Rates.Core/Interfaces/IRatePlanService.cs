using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRatePlanService
    {
        ServiceResult<IReadOnlyList<RatePlanDTO>> GetAll();

        ServiceResult<RatePlanDTO> GetRatePlansById(int Id);
    }
}
