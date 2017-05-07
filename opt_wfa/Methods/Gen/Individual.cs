using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenUnits;
using System;
using System.Collections.Generic;

namespace opt_wfa.Methods.Gen
{
   
   
    public class Gen<T>
    {
        T gen;
        public Gen(T t)
        {
            this.gen = t;
        }
    }

  
    
    
    public class converter
    {
        double max = 10;
        double min = -10;
        int genLength = 12;

        private int Decoder(double r)
        {
            double  gg = (r - min) * (Math.Pow(2, genLength) - 1) / (max - min);
            int g = (int)Math.Floor(gg);
            return g;
        }
       
        private double Coder(int g)
        {

            double r = g*(max - min) / (Math.Pow(2, genLength) - 1) - min;
            return r;
        }

    }

    
}
