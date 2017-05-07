using opt_wfa.Data_Types;
using opt_wfa.Factory;
using opt_wfa.Functions;

namespace opt_wfa.Methods
{

    public class M8_Combo_LineSeach : Combo_LineSeach<dsk_line, Davidon_line>, ICombo_LineSeach
    {
        public Vector X { set { _X = value; } }
        public Vector P { set { _P = value; } }
        public iFunc concrete { set { _concrete = value; } }

        public double Combo_LineSearch(double x1, int iter1, int iter2)
        {
            return base.Combo_LineSearch(x1, iter1, iter2);

        }
    }
}
