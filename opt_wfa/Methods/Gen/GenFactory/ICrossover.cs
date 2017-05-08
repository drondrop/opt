using opt_wfa.Data_Types;


namespace opt_wfa.Methods.Gen.GenFactory
{
    public interface ICrossover
    {
        void Crossover(ref Individual A, ref Individual B, RandomHelper rnd);
    }

}
