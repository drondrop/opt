﻿using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;

namespace opt_wfa.Methods.Gen
{
    public class Individual
    {
        private GenoType _genotype;
        private double _fitness;
        private int length;
        public Individual(GenoType _GenoType)
        {
            // this._phenotype = _phenotype;
            this._genotype = _GenoType;
        }
        public double fitness { get { return _fitness; } set { _fitness = value; } }
        public Vector Phenotype
        {
            get
            {
                return _genotype.GetPhenoType();
            }
        }
        public GenoType Genotype { get { return _genotype; } set { _genotype = value; } }
        public int PhenotypeLength { get { return length; } }
        public int GenotypeLength { get { return _genotype.length; } }
    }
   
    public class Gen<T>
    {
        T gen;
        public Gen(T t)
        {
            this.gen = t;
        }
    }

   public interface GenoType
    {
         Vector GetPhenoType();
         int length { get; }
         

    }
    public class GenoTypeInt : GenoType
    {
        List<int> genoType = new List<int>();
        public List<int> GenoType { get { return genoType; } set { genoType = value; } }
        public Vector GetPhenoType()
        {
            return new Vector(genoType.Count);
        }
        public int length { get { return genoType.Count; } }
    }
    public class GenoTypeDouble : GenoType
    {

        List<double> genoType ;
        int phenLength;
        public GenoTypeDouble(double [] massIn)
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
        public int length { get{return genoType.Count ;}  }




        private double[] Decoder()
        {
            double[] massOut = new double[phenLength];
            for (int i = 0; i < phenLength; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    massOut[i] += genoType[i * 12 + j];
                }
                massOut[i] /= 12.0;
            }
            return massOut;
        }
        private void Coder(double[] massIn)
        {
            int count = phenLength * 12;
            genoType = new List<double>();//new Vector((_phenotype.length * 12));

            for (int i = 0; i < phenLength; i++)
            {
                for (int j = 0; j < 12;j++ )
                {
                    genoType.Add( massIn[i]);
                }
                    
            }
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
