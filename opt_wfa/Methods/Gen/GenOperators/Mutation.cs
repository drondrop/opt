using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenFactory;
using opt_wfa.Methods.Gen.GenUnits;

namespace opt_wfa.Methods.Gen.GenFactory
{
    
    public class Mutation1 : GenOperatorBase,IMutation
    {
        private double _Pm = 0.045;
        public Mutation1(double _Pm, IGenOperator _op)
            : base(_op)
        {
            // TODO: Complete member initialization
            this._Pm = _Pm;
        }
        public void Mutation(ref Individual individual, RandomHelper rnd)
        {
            base._GenOperator.Mutate(ref individual,_Pm,rnd);

        }
    }
}
