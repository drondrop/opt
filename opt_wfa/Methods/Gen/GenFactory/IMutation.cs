using opt_wfa.Data_Types;


namespace opt_wfa.Methods.Gen.GenFactory
{
    public interface IMutation
    {
        void Mutation(ref Individual individual, RandomHelper rnd);
    }
}
