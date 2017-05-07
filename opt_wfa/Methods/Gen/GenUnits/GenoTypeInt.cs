using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenUnits
{
    public class GenoTypeInt : GenoType
    {
        List<int> genoType = new List<int>();
        public List<int> GenoType { get { return genoType; } set { genoType = value; } }
        public Vector GetPhenoType()
        {
            return new Vector(genoType.Count);
        }
        public int length { get { return genoType.Count; } }


        public GenoType Clone(GenoType old)
        {
            throw new NotImplementedException();
        }


        public GenoType Clone()
        {
            throw new NotImplementedException();
        }
    }
}
