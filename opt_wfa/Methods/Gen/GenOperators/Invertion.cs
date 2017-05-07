using opt_wfa.Methods.Gen.GenFactory;

namespace opt_wfa.Methods.Gen.GenOperators
{
    
    public class ConcreteInvertion :GenOperatorBase, IInvertion
    {
        public ConcreteInvertion(IGenOperator _op) : base(_op) { }
    }
}
