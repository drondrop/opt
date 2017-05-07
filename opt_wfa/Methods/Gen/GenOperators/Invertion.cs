using opt_wfa.Methods.Gen.GenFactory;
using opt_wfa.Methods.Gen.GenUnits;

namespace opt_wfa.Methods.Gen.GenFactory
{
    
    public class ConcreteInvertion :GenOperatorBase, IInvertion
    {
        public ConcreteInvertion(IGenOperator _op) : base(_op) { }
    }
}
