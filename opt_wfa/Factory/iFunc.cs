using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;

namespace opt_wfa.Factory
{
    public interface iFunc
    {
        double f(Vector X);
        int arguments { get; }
        Vector X_0 { get; }
    }
}
