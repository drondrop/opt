using opt_wfa.Data_Types;
using opt_wfa.Methods.Gen.GenUnits;

namespace opt_wfa.Methods.Gen.GenFactory
{
    public interface IMutation
    {
        void Mutation(ref Individual individual, RandomHelper rnd);
    }
}
