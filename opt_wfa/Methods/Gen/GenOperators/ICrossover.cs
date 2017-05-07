using opt_wfa.Data_Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opt_wfa.Methods.Gen.GenOperators
{
    

    interface ICrossover
    {
        void Crossover(ref Individual A, ref Individual B, RandomHelper rnd);
    }

    public static class ICrossoverFactory
    {
        
    }


    public class CrossoverOnePoint :GenOperatorBase, ICrossover
    {
        public void Crossover(ref Individual A, ref Individual B, RandomHelper rnd)
        {
           // int gensLength = A.GenotypeLength;
            //int genPoint = (int)Math.Round(rnd.nextDouble() * gensLength);
            base._GenOperator.Cross(ref A, ref B, rnd.nextDouble());
            //A.Cross(ref B, genPoint);
        }

    }
    public class CrossoverTwoPoint :GenOperatorBase, ICrossover
    {
        public void Crossover(ref Individual A, ref Individual B, RandomHelper rnd)
        {

            base._GenOperator.Cross(ref A, ref B, rnd.nextDouble());
            base._GenOperator.Cross(ref A, ref B, rnd.nextDouble());
            
        }

    }

   

   
}

