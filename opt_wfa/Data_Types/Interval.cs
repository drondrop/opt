
namespace opt_wfa.Data_Types
{
    public struct Interval
    {
        public double a;
        public double b;
        public double mid { get { return (a + b) * 0.5; } }
    }
    public delegate double func_Delegate(double X);

    public struct calculateParams
    {
        public double eps;
        public int max;
        public int maxComboLine1Count;
        public int maxComboLine2Count;
    }
}
