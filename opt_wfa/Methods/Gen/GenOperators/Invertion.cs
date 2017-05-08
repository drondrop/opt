using opt_wfa.Methods.Gen.GenFactory;



namespace opt_wfa.Methods.Gen.GenFactory
{
    public partial class gFactory
    {
        private class ConcreteInvertion : GenOperatorBase, IInvertion
        {
            private double _Pi;
            public ConcreteInvertion(IGenOperator _op, double _Pi = 0.1)
                : base(_op)
            {
                this._Pi = _Pi;
            }

            public void Invert(ref Individual individual, Data_Types.RandomHelper _random)
            {
                base._GenOperator.Invert(ref individual, _Pi, _random);
            }
        }
    }
}
