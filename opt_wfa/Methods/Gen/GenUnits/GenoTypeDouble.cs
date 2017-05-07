using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenUnits
{
    public class GenoTypeDouble : GenoType
    {


        List<double> genoType;
        int phenLength;
        int mult = 12;
        public GenoTypeDouble(double[] massIn)
        {
            this.phenLength = massIn.Length;
            //  this.genoType = new List<double>(massIn);
            Coder(massIn);

        }
        public List<double> GenoType { get { return genoType; } set { genoType = value; } }
        public Vector GetPhenoType()
        {
            return new Vector(Decoder());
        }
        public int length { get { return genoType.Count; } }




        private double[] Decoder()
        {
            double[] massOut = new double[phenLength];
            for (int i = 0; i < phenLength; i++)
            {
                for (int j = 0; j < mult; j++)
                {
                    massOut[i] += genoType[i * mult + j];
                }
                massOut[i] /= mult;
            }
            return massOut;
        }
        private void Coder(double[] massIn)
        {
            int count = phenLength * mult;
            genoType = new List<double>();//new Vector((_phenotype.length * 12));

            for (int i = 0; i < phenLength; i++)
            {
                for (int j = 0; j < mult; j++)
                {
                    genoType.Add(massIn[i]);
                }

            }
        }




        public GenoType Clone()
        {
            return new GenoTypeDouble(this.Decoder());
        }
    }
}
