using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenFactory;

using System;


  namespace opt_wfa.Methods.Gen.GenFactory
{
  public interface IGenOperator
   {
      void Mutate(ref Individual A, double _Pm, RandomHelper rnd);
      void Invert(ref Individual A, double _Pi, RandomHelper rnd);
      void Cross(ref Individual A, ref Individual B, double Position);
   }


    public partial class gFactory
    {
        private class RealGenOperator : IGenOperator
        {
            public void Cross(ref Individual A, ref Individual B, double Position)
            {
                int gensLength = A.GenotypeLength;
                int genPoint = (int)Math.Round(Position * gensLength);
                for (int i = 0; i < A.GenotypeLength; i++)
                {
                    if (i < genPoint)
                    {
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i];
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)B.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)B.Genotype).GenoType[i];
                    }
                    else
                    {
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)B.Genotype).GenoType[i];
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)B.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i];
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
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i] += rnd.nextDouble() - 0.5;
                    }
                }
            }

            public void Invert(ref Individual A, double _Pi, RandomHelper rnd)
            {
                int gensLength = A.Genotype.length;
                for (int i = 0; i < gensLength; i++)
                {
                    if (_Pi > rnd.nextDouble())
                    {
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i] = -((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeDoubleA)A.Genotype).GenoType[i];
                        break;
                    }
                }
            }
        }

        private class IntGenOperator : IGenOperator
        {
            public void Cross(ref Individual A, ref Individual B, double Position)
            {
                int genLength = 12;
                int gensLength = A.GenotypeLength;
                int genPointIngen = (int)Math.Round(Position * genLength);
                int genPoint = (int)Math.Round(Position * gensLength);
                for (int i = 0; i < A.GenotypeLength; i++)
                {
                    if (i == genPoint)
                    {
                        //  A.Genotype[i] = A.Genotype[i];
                        // B.Genotype[i] = B.Genotype[i];


                        int mask = (int)Math.Round(Math.Pow(2, genPointIngen) - 1); // какие биты менять, а какие нет (1-обмениваем битами, 0-оставляем)
                        int swapMask = (((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i] ^ ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i]) & mask;

                        int res1 = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i];
                        int res2 = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i];

                        res1 ^= swapMask;
                        res2 ^= swapMask;
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i] = res1;
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i] = res2;

                    }
                    if (i < genPoint)
                    {
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i];
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i];
                    }
                    if (i > genPoint)
                    {
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i];
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)B.Genotype).GenoType[i] = ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i];
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
                        int mask = (int)Math.Floor(Math.Pow(2, rnd.nextDouble() * 12)) - 1;
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i] ^= mask;
                    }
                }
            }

            public void Invert(ref Individual A, double _Pi, RandomHelper rnd)
            {
                int gensLength = A.Genotype.length;
                for (int i = 0; i < gensLength; i++)
                {
                    if (_Pi > rnd.nextDouble())
                    {
                        int mask = (int)Math.Floor(Math.Pow(2, rnd.nextDouble() * 12)) - 1;
                        int mask2 = (int)Math.Floor(Math.Pow(2, 12)) - 1 - mask;
                        ((opt_wfa.Methods.Gen.GenFactory.gFactory.GenoTypeIntA)A.Genotype).GenoType[i] &= mask;
                        break;
                    }
                }
            }
        }
    }
}
