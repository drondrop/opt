using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Data_Types
{
    public class ABcontainer<T>
    {
        private T _A, _B;
        public ABcontainer(T _A, T _B)
        {
            this._A = _A;
            this._B = _B;
        }
        public T A { get { return _A; } set { _A = value; } }
        public T B { get { return _B; } set { _B = value; } }
    }
}
