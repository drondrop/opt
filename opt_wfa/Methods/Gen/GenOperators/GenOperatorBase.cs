using opt_wfa.Methods.Gen.GenFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenOperators
{
    public class GenOperatorBase
    {
        protected IGenOperator _GenOperator;//=new RealGenOperator();
        protected GenOperatorBase(IGenOperator _IGenOperator)
        {
            _GenOperator = _IGenOperator;
        }
    }
}
