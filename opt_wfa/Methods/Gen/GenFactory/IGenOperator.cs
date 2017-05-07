using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenUnits;
using System;

namespace opt_wfa.Methods.Gen.GenFactory
{
  
  public interface IGenOperator
   {
      void Mutate(ref Individual A, double _Pm, RandomHelper rnd);
      
     //  public void Invert();

      void Cross(ref Individual A, ref Individual B, double Position);
   }
    public class RealGenOperator:IGenOperator
    {
        public void Cross(ref Individual A, ref Individual B, double Position)
        {
            int gensLength = A.GenotypeLength;
            int genPoint = (int)Math.Round(Position * gensLength);
            for (int i = 0; i < A.GenotypeLength; i++)
            {
                if (i < genPoint)
                {
                  ((GenoTypeDouble)  A.Genotype).GenoType[i] =  ((GenoTypeDouble) A.Genotype).GenoType[i];
                  ((GenoTypeDouble)B.Genotype).GenoType[i] = ((GenoTypeDouble)B.Genotype).GenoType[i];
                }
                else
                {
                    ((GenoTypeDouble)A.Genotype).GenoType[i] = ((GenoTypeDouble)B.Genotype).GenoType[i];
                    ((GenoTypeDouble)B.Genotype).GenoType[i] = ((GenoTypeDouble)A.Genotype).GenoType[i];
                }
            }
        }

        public void Mutate(ref Individual A, double _Pm, RandomHelper rnd)
        {
            int gensLength = A.Genotype.length;
            for (int i = 0; i < gensLength; i++)
            {
                if (_Pm > rnd.nextDouble())
                {
                    ((GenoTypeDouble)A.Genotype).GenoType[i] += rnd.nextDouble() - 0.5;
                }
            }
        }
    }

    public class IntGenOperator : IGenOperator
    {
        public void Cross(ref Individual A, ref Individual B, double Position)
        {
            int genLength = 12;
            int gensLength = A.GenotypeLength;
            int genPointIngen = (int)Math.Round(Position * genLength);
            int genPoint = (int)Math.Round(Position * gensLength);
            for (int i = 0; i < A.GenotypeLength; i++)
            {
                //if (i == genPoint)
                //{
                //    A.Genotype[i] = A.Genotype[i];
                //    B.Genotype[i] = B.Genotype[i];


                //    int mask = (int)Math.Round(Math.Pow(2, i + 1) - 1); // какие биты менять, а какие нет (1-обмениваем битами, 0-оставляем)
                //    int swapMask = ((int)A.Genotype[i] ^ (int)B.Genotype[i]) & mask;

                //    int res1 = (int)A.Genotype[i];
                //    int res2 = (int)B.Genotype[i];

                //    res1 ^= swapMask;
                //    res2 ^= swapMask;
                //    A.Genotype[i] = res1;
                //    B.Genotype[i] = res2;

                //}
                //if (i < genPoint)
                //{
                //    A.Genotype[i] = A.Genotype[i];
                //    B.Genotype[i] = B.Genotype[i];
                //}
                //if (i > genPoint)
                //{
                //    A.Genotype[i] = B.Genotype[i];
                //    B.Genotype[i] = A.Genotype[i];
                //}
            }
        }

        public void Mutate()
        {
            throw new NotImplementedException();
        }

        public void Mutate(ref Individual A, double _Pm, RandomHelper rnd)
        {
            throw new NotImplementedException();
        }
    }




  
}
