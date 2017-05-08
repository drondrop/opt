using opt_wfa.Data_Types;

using System;
using System.Collections.Generic;

namespace opt_wfa.Methods.Gen.GenFactory
{
    public partial class gFactory
    {
        public abstract class  GenoTypeIntA : GenoType
        {
            protected List<int> genoType = new List<int>();
            protected int phenLength;
            public List<int> GenoType { get { return genoType; } set { genoType = value; } }
            

             protected void Coder(double[] massIn)
            {
                genoType = new List<int>();//new Vector((_phenotype.length * 12));
                for (int i = 0; i < phenLength; i++)
                {
                    genoType.Add(converter.Decoder(massIn[i]));
                }
            }


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

                    massOut[i] = converter.Coder(this.genoType[i]);
                }
                return massOut;
            }
            public GenoType Clone()
            {
                return new GenoTypeInt(this.Decoder());
            }
        }
    }
    public static class converter
    {
        static double max = 10;
        static double min = -10;
        static int genLength = 12;

        public static int Decoder(double r)
        {
            double gg = (r - min) * (Math.Pow(2, genLength) - 1) / (max - min);
            int g = (int)Math.Floor(gg);
            return g;
        }

        public static double Coder(int g)
        {

            double r = g * (max - min) / (Math.Pow(2, genLength) - 1) + min;
            return r;
        }

    }
}
