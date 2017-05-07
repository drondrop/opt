using opt_wfa.Data_Types;
using opt_wfa.Factory;
using opt_wfa.Functions;
using System;
namespace opt_wfa.Methods
{
    public interface ICombo_LineSeach
    {
        double Combo_LineSearch(double x1, int iter1, int iter2);
        Vector X { set ; }
        Vector P { set; }
        iFunc concrete { set ;  }
    }
}
