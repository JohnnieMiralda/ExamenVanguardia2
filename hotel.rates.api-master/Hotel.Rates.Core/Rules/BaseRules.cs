using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Rules
{
    public interface BaseRules
    {
        double validRules(int id , double days);

        
    }
}
