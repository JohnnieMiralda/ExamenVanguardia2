using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRatePlanRepository
    {
        IReadOnlyList<RatePlan> GetAll();

        RatePlan GetById(int id);

    }
}
