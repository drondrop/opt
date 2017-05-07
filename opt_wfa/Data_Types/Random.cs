using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Data_Types
{
    public class RandomHelper
    {
        private Random _rnd;
        public RandomHelper()
        {
            _rnd = new Random();

        }
        public double nextDouble()
        {
            return _rnd.NextDouble();
        }
    }
}
