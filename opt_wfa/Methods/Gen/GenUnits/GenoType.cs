using opt_wfa.Data_Types;

namespace opt_wfa.Methods.Gen.GenFactory
{
    public interface GenoType
    {
        Vector GetPhenoType();
        int length { get; }
        GenoType Clone();

    }
}
