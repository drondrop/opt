using opt_wfa.Data_Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenFactory
{
   
    public partial class gFactory
    {
        public abstract class GenoTypeDoubleA : GenoType
        {
            protected List<double> genoType;
            protected int phenLength;
            protected int mult = 12;

            public List<double> GenoType { get { return genoType; } set { genoType = value; } }
            public Vector GetPhenoType()
            {
                return new Vector(Decoder());
            }
            public int length { get { return genoType.Count; } }
            protected double[] Decoder()
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
            protected void Coder(double[] massIn)
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
}
