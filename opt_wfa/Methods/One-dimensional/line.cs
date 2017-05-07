using opt_wfa.Data_Types;
using System;

namespace opt_wfa.Methods
{
    
    public class dsk_line : ILineSearch
    {
        public double Search(func_Delegate f, double x1, ref double a1, ref double b1, int maxIter, int icount, double eps)
        {
            double h1 = eps * 0.01, h2;
            double x0 = (a1 + b1) / 2, newX, oldX;
            double a, b, c, d, x_m;
            int k = 1;
            do
            {
                newX = x0 + h1;
                if (f(newX) < f(x0))
                {
                    h1 = h1;
                }
                else
                {
                    h1 = -h1;
                }
                oldX = x0;
                newX = x0 + h1;
                h2 = h1;
                while (f(newX) <= f(oldX))
                {
                    oldX = newX;
                    newX = oldX + h2;
                    h2 *= 10;
                }

                a = oldX;
                b = (oldX + newX) / 2;
                c = newX;
                //Sveng3 (f, x0, a, b, c, h1);
                if ((f(a) - 2 * f(b) + f(c))<eps)
                {
                    x_m = b; d = b;
                    break;
                }
                d = b + 0.5 * (b - a) * (f(a) - f(c)) / (f(a) - 2 * f(b) + f(c));
                if ((b - d) / b <= eps && (f(b) - f(d)) / f(b) <= eps)
                {
                    x_m = (b + d) / 2;
                    break;
                }
                else
                {
                    if (f(b) < f(d))
                        x0 = b;
                    else
                        x0 = d;
                    h1 = h1 / 2;
                }
            } while (++k < maxIter);


            x_m = (b + d) / 2;
            if (b < d)
            {
                a1 = b;
                b1 = d;
            }
            else
            {
                a1 = d;
                b1 = b;
            }
            icount = k;
            return x_m;
        }
    }

    public class Davidon_line : ILineSearch
    {
        public double Search(func_Delegate f, double x0, ref double a, ref double b, int maxIter, int icount, double eps)		// максимальное количество итераций
        {
            int k = 1;
            double z, w, r;
            if (a > b)
            {
                r = b;
                b = a;
                a = r;
            }
            double dfa = dfp(f, a);
            double dfb = dfp(f, b);

            z = dfa + dfb + 3 * (f(a) - f(b)) / (b - a); //(b - a)
            w = Math.Sqrt(z * z - dfa * dfb);
            r = a + (b - a) * (z - dfa + w) / (dfb - dfa + 2 * w);
            double dfa_b = dfp(f, ((a + b) / 2));
            double dfr = dfp(f, r);

            while ((Math.Abs(dfa_b)) > eps && Math.Abs(a - b) > eps && k < maxIter && dfr > eps)
            {
                k++;
                if (dfr < 0)
                    a = r;
                else
                    b = r;



                dfa = dfp(f, a);
                dfb = dfp(f, b);

                z = dfa + dfb + 3.0 * (f(a) - f(b)) / (b - a);
                w =Math.Sqrt(z * z - dfa * dfb);
                r = a + (b - a) * (z - dfa + w) / (dfb - dfa + 2.0 * w);

                dfr = dfp(f, r);
                dfa_b = dfp(f, ((a + b) / 2.0));
            }
            double res = 0;
            if (Math.Abs(dfr) < Math.Abs(dfa_b))
            {
                res = r;
            }
            else
            {
                res = (a + b) / 2;
            }
            icount = k;

            return res;
        }
        double dfp(func_Delegate f, double x)
        {
            double h = 0.000001;
            double hinv = 1000000;
            return (-f(x + 2 * h) +
                    8 * f(x + h) -
                    8 * f(x - h) +
                    f(x - 2 * h)) * hinv / 12.0;
        }
}
}

