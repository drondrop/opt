

using opt_wfa.Data_Types;
using System.Reflection;
namespace opt_wfa.Factory
{


    public class Core
    {
        private iFunc _concrete_test_func;
        private IMethod _concrete_method;
        calculateParams _calc;
        
        public Core(string concrete_method, string concrete_test_func,calculateParams calc)
        {
            var funcFactory = new Factory<iFunc>();
            var methodFactory = new Factory<IMethod>();
            funcFactory.ScanForT(Assembly.GetExecutingAssembly());
            methodFactory.ScanForT(Assembly.GetExecutingAssembly());
            var func = funcFactory.Create(concrete_test_func);
            var method = methodFactory.Create(concrete_method);
            _concrete_test_func = func;
            _concrete_method = method;
            _calc = calc;
        }
        public int Calculate(ref Vector X0)
        {
            X0 = _concrete_test_func.X_0;
           return _concrete_method.Method(_concrete_test_func, ref X0, _calc);
        }
        public iFunc test_func { get { return _concrete_test_func; } }
      

    }
   
}
