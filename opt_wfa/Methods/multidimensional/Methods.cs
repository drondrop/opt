using opt_wfa.Data_Types;
using opt_wfa.Factory;
using System;
using System.Collections.Generic;

namespace opt_wfa.Methods
{

    public abstract class Method
    {
        protected ICombo_LineSeach comboLine = comboFactory.create(comboFactory.M_VAR.M8);
        protected Vector gradient(iFunc test_func, Vector X, calculateParams ct_core)
        {
            Vector result = new Vector(X);
            Vector step_before = new Vector(X);
            Vector step_after = new Vector(X);
            double h = Math.Pow(10, -9);
            for (int i = 0; i < X.length; i++)
            {
                step_before[i] -= h;
                step_after[i] += h;
                result[i] = ((test_func.f(step_before) - 4 * test_func.f(X) + 3 * test_func.f(step_after)) / (2 * h));
            }
            return result;
        }
    }
    public class huka_jivs : Method, IMethod
    {
        public int Method1(iFunc test_func, ref Vector X, calculateParams ct_core)
        {
            double shag = 1;
            double beta = 10;
            Vector x1 = new Vector(X);
            Vector x4 = new Vector(x1);
            Vector x3 = new Vector(x1);
            Vector x2 = new Vector(x1);
            double test = shag;
            int i = 0;
            do
            {
                test = shag;
                x2 = find_st(test_func, x1, test, ct_core);
                while (test_func.f(x2) > test_func.f(x1))
                {
                    test /= beta;
                    x2 = find_st(test_func, x1, test, ct_core);
                    if (test < ct_core.eps)
                        break;
                }

                x3 = 2 * x2 - x1;
                x4 = find_st(test_func, x3, test, ct_core);
                if (test_func.f(x4) < test_func.f(x3))
                {
                    x1 = x2;
                    x2 = x4;
                }
                else
                {
                    //x1 = x2;
                    shag /= beta;
                }
                i++;
            }
            while ((gradient(test_func, x2, ct_core).norm()) > ct_core.eps && i < ct_core.max);
            X = x2;
            return i;
        }

        public int Method(iFunc test_func, ref Vector X, calculateParams ct_core)
        {


            var x = new Vector(X);

    
            int itera = 0;

        

            double shag = 1;
           
           var x4 = new Vector(x);
           var x3 = new Vector(x);
           var x2 = new Vector(x);
          
           var l = new Vector(x);
           var r = new Vector(x);

            do
            {
                double test = shag;

                x2=Poisk(x,   test,test_func);
                while (test_func.f(x2) > test_func.f(x))
                {
                    test /= 2;
                x2=    Poisk(x,   test,test_func);
                    if (test < ct_core.eps)
                    {
                        X = x2;
                        return itera;
                    }
                        
                }


                x3 = 2 * x2 - x;

                x4= Poisk(x3, test,test_func);

                if (test_func.f(x4) < test_func.f(x3))
                {
                    x = x2;
                    x2 = x4;
                }
                else
                    shag /= 2;

                itera++;
            }
            while ((gradient(test_func, x2, ct_core).norm()) > ct_core.eps && itera < ct_core.max);
            X = x2;
            return itera;
           
        }

        public static Vector Poisk(Vector x,  double sh, iFunc test_func)
        {
           var l = new     Vector(x);
           var r = new     Vector(x);
           var temp = new Vector(x);
            for (int i = 0; i < x.length; i++)
            {
                l[i] -= sh;
                r[i] += sh;

                if (test_func.f(x) > test_func.f(r))
                    temp[ i] = r[ i];
                if (test_func.f(x) > test_func.f(l))
                    temp[ i] = l[ i];
                if (test_func.f(x) == test_func.f(l) && test_func.f(x) == test_func.f(r))
                    temp[ i] = x[ i];
            }
            return temp;

        }



        public Vector find_st(iFunc test_func, Vector X, double step, calculateParams ct_core)
        {
            Vector poi = new Vector(X);
            for (int i = 0; i < X.length; i++)
            {
                poi[i] += step;
                if (test_func.f(X) > test_func.f(poi))
                {
                    X = new Vector(poi);
                }
                else
                {
                    poi[i] -= 2 * step;
                    if (test_func.f(X) > test_func.f(poi))
                    {
                        X = poi;
                    }
                }
            }
            return X;        
        }
    }

    public class Rozenbrok : Method, IMethod
    {
        public int Method(iFunc test_func, ref Vector X, calculateParams ct_core)
        {
            int N = X.length;
            Vector X_b = new Vector(X);
            Vector x3 = new Vector(X);
            Vector alpha = new Vector(X);
            Vector Yj = new Vector(X);
            List<Vector> S = new List<Vector>();
            int k = 0;

            for (int i = 0; i < N; i++)
            {
                S.Add(new Vector(N));
                S[i][i] = 1;
            }

            Interval interval = new Interval();

            while (k < ct_core.max)
            {
                for (int j = 0; j < N; j++)
                {
                    x3 = new Vector(Yj);
                    comboLine.P = S[j];
                    comboLine.X = x3;
                    comboLine.concrete = test_func;
                    alpha[j] = comboLine.Combo_LineSearch(0.0, ct_core.maxComboLine1Count, ct_core.maxComboLine2Count);//interval.mid;
                    Yj = Yj + S[j] * alpha[j];
                }

                if (gradient(test_func, Yj, ct_core).norm() < ct_core.eps)
                    break;

                S = gramm_shmidt(S, alpha, ct_core.eps);
                X_b = new Vector(Yj);
                k++;
            }
            X = Yj;
            return k;
        }
        private List<Vector> gramm_shmidt(List<Vector> d, Vector alpha, double eps)
        {
            Vector Aj = new Vector(d[0].length);
            Vector Bj = new Vector(d[0].length);
            Vector temp = new Vector(d[0].length);
            List<Vector> A = new List<Vector>(d[0].length);

            List<Vector> B = new List<Vector>(d[0].length);
            for (int i = 0; i < d.Count; i++)
            {
                A.Add(new Vector(d[0].length));
                for (int j = i; j < d.Count; j++)
                {
                    A[i] += d[j] * alpha[j];
                }
            }

            d[0] = new Vector(A[0] / A[0].norm());

            for (int i = 1; i < d.Count; i++)
            {
                temp -= temp;
                for (int j = 0; j < i; j++)
                {
                    temp += A[i] - (A[i].trans() * d[j]) * d[j];
                }
                // d[i] = d[i] - temp;
                d[i] = temp / temp.norm();
            }
            return d;
        }
    }

    public class Pauwell : Method, IMethod
    {
        public int Method(iFunc test_func, ref Vector X, calculateParams ct_core)
        {

            int N = X.length;


            double alpha = 0;
            Vector A = new Vector(X);
            Vector alpha1 = new Vector(X);
            Vector Y = new Vector(X);
            Vector X1 = new Vector(X);

            List<Vector> S = new List<Vector>();
            int k = 0;

            S.Add(new Vector(N));
            S[0][N - 1] = 1;
            for (int i = 0; i < N; i++)
            {
                S.Add(new Vector(N));
                S[i + 1][i] = 1;
            }

            comboLine.concrete = test_func;
            int j = 0;
            while (gradient(test_func, X, ct_core).norm() > ct_core.eps && ct_core.max > k)
            {
                j = 0;
                foreach (var P in S)
                {

                    comboLine.P = P;
                    comboLine.X = X;
                    alpha = comboLine.Combo_LineSearch(0, ct_core.maxComboLine1Count, ct_core.maxComboLine2Count);
                    X = new Vector(X + alpha * P);
                    if (j == 0) X1 = X;
                    j++;
                }
                Y = X - X1;
                S[0] = new Vector(Y);
                for (int i = 1; i < S.Count - 1; i++)
                {
                    S[i] = S[i + 1];
                }
                S[N] = new Vector(Y);
                k++;
            }

            return k;
        }
    }
}
