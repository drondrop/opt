using opt_wfa.Data_Types;
using opt_wfa.Factory;
using opt_wfa.Functions;
using System;
using System.Collections.Generic;

namespace opt_wfa.Methods
{
    public abstract class Combo_LineSeach<ML1,ML2> 
        where ML1:  ILineSearch, new()
        where ML2 : ILineSearch, new()
    {
      //  protected ILineMethod _getInterval;
        protected ILineSearch _method1;
        protected ILineSearch _method2;
        protected Vector _X;
        protected Vector _P;
        protected iFunc _concrete;
        protected Combo_LineSeach()
        {
            //_getInterval = getInterval;
            _method1 =new ML1();
            _method2 =new ML2();
        }
        protected Vector conv(double alpha)
        {
            Vector X = new Vector(_X);
            X = _X + alpha * _P;
            return X;
        }
        protected double func(double alpha)
        {
            return _concrete.f(_X + alpha * _P);
        }
        protected double Combo_LineSearch(double x1, int iter1, int iter2)
        {
            int max1i = 100;
            int max2i = 50;
            double a = 0, b = 0; 
            double result = 0;
            double DEFAULT_EPSILON = 0.0000001;
            Swann1(func, x1, ref a, ref b);
            _method1.Search(func, x1, ref a, ref b, max1i, iter1, DEFAULT_EPSILON);
            result = _method2.Search(func, x1, ref a, ref b, max2i, iter2, DEFAULT_EPSILON);
            return result;
        }
        
        protected void Swann1(func_Delegate f, double x0, ref double a, ref double b)
        {
            double h, h2, h3;
            h = 0.0001;
            x0 = 0;
            h2 = h + x0;
            h3 = h2;
            if (f(h) > f(x0))
            {
                h = -h;
                h2 = h;
                h3 = h2;
            }
            do
            {
                h2 = h3;
                h = 2 * h;
                h3 = h2 + h;
            } while (f(h2) > f(h3));

            a = h2 - 0.5 * h;
            b = h3;
            if (a > b)
            {
                a = b + a;
                b = a - b;
                a = a - b;
            }
        }
    }

    public static class comboFactory
    {
        public enum M_VAR
        {
            M1, M2, M3, M4, M5, M6, M7, M8
        }
        private static IDictionary<M_VAR, ICombo_LineSeach> _Factories = new Dictionary<M_VAR, ICombo_LineSeach> {
                { M_VAR. M8,  new M8_Combo_LineSeach() }};

        public static ICombo_LineSeach create(M_VAR type)
        {
            ICombo_LineSeach instance;
            if (!_Factories.TryGetValue(type, out instance))
                throw new Exception(string.Format("No factory for enum value {0}", type));
            return instance;
        }
    }
}
