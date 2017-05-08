using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenFactory;


namespace opt_wfa.Methods.Gen.GenFactory
{



    public partial class gFactory
    {

        private class CrossoverOnePoint : GenOperatorBase, ICrossover
        {
            public CrossoverOnePoint(IGenOperator _op) : base(_op) { }
            public void Crossover(ref Individual A, ref Individual B, RandomHelper rnd)
            {
                // int gensLength = A.GenotypeLength;
                //int genPoint = (int)Math.Round(rnd.nextDouble() * gensLength);
                base._GenOperator.Cross(ref A, ref B, rnd.nextDouble());
                //A.Cross(ref B, genPoint);
            }

        }
        private class CrossoverTwoPoint : GenOperatorBase, ICrossover
        {
            public CrossoverTwoPoint(IGenOperator _op) : base(_op) { }
            public void Crossover(ref Individual A, ref Individual B, RandomHelper rnd)
            {

                base._GenOperator.Cross(ref A, ref B, rnd.nextDouble());
                base._GenOperator.Cross(ref A, ref B, rnd.nextDouble());

            }

        }

    }
   
}

