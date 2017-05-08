using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenFactory;


namespace opt_wfa.Methods.Gen.GenFactory
{
    public partial class gFactory
    {
        private class Mutation1 : GenOperatorBase, IMutation
        {
            private double _Pm;
            public Mutation1(IGenOperator _op, double _Pm = 0.1)
                : base(_op)
            {
                // TODO: Complete member initialization
                this._Pm = _Pm;
            }
            public void Mutation(ref Individual individual, RandomHelper rnd)
            {
                base._GenOperator.Mutate(ref individual, _Pm, rnd);

            }
        }
    }
}
