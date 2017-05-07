using opt_wfa.Data_Types;
namespace opt_wfa.Methods
{
    public interface ILineSearch
    {
       
        double Search(func_Delegate f, double x1, ref double a1, ref double b1, int maxIter, int icount, double eps);
    }
}


