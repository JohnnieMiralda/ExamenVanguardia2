using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Enums
{
    public enum ResponseCode
    {   
        Ok,
        BadRequest,
        Success,
        Error,
        InternalServerError = 500,
        NotFound
    }
}
