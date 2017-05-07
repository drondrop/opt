using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenOperators
{
    public  interface IInvertion
    {

    }
    public class ConcreteInvertion :GenOperatorBase, IInvertion
    {
        public ConcreteInvertion(IGenOperator _op) : base(_op) { }
    }
}
