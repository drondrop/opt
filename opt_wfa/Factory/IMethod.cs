using opt_wfa.Data_Types;
using opt_wfa.Functions;
using System;

namespace opt_wfa.Factory
{
   public interface IMethod
    {
       int Method(iFunc func, ref Vector X, calculateParams ct_core);
    }

    
   
    //public interface ILineMethod
    //{
    //    int Method(ref Vector X,ref Interval interval, Vector P,  Core ct_core ,int max);
    //}
    //public class pauel1 : ILineMethod
    //{
    //    public int Method(ref Vector X, ref Interval interval, Vector P, Core ct_core, int max)
    //    {
    //        double b = (interval.a + interval.b) / 2, d, e = ct_core.eps;
    //        int k = 1;

    //        d = (ct_core.test_func.f(X + interval.a * P) * (b * b - interval.b * interval.b) + ct_core.test_func.f(X + b * P) * (interval.b * interval.b - interval.a * interval.a) + ct_core.test_func.f(X + interval.b * P) * (interval.a * interval.a - b * b)) /
    //            ((ct_core.test_func.f(X + interval.a * P) * (b - interval.b) + ct_core.test_func.f(X + b * P) * (interval.b - interval.a) + ct_core.test_func.f(X + interval.b * P) * (interval.a - b)) * 2);


    //        while (k < max && Math.Abs((b - d) / b) > e && (Math.Abs((ct_core.test_func.f(X + b * P) - ct_core.test_func.f(X + d * P)) / ct_core.test_func.f(X + b * P)) > e))
    //        {
    //            if (ct_core.test_func.f(X + b * P) > ct_core.test_func.f(X + d * P))
    //            {
    //                if (b < d)
    //                    interval.a = b;
    //                else
    //                    interval.b = b;
    //                b = d;
    //            }
    //            else
    //            {
    //                if (b < d)
    //                    interval.b = d;
    //                else
    //                    interval.a = d;
    //            }
    //            d = (interval.a + b) / 2 + (ct_core.test_func.f(X + interval.a * P) - ct_core.test_func.f(X + b * P)) * (ct_core.test_func.f(X + interval.a * P) - ct_core.test_func.f(X + b * P)) * (b - interval.b) * (interval.b - interval.a) /
    //                ((ct_core.test_func.f(X + interval.a * P) * (b - interval.b) + ct_core.test_func.f(X + b * P) * (interval.b - interval.a) + ct_core.test_func.f(X + interval.b * P) * (interval.a - b)) * 2);


    //            k++;
    //        }
    //        interval.a = b;
    //        interval.b = d;
    //        X = X + ((interval.a + b) / 2) * P;
    //        return k;
    //    }
    //}



    //public class pauel : ILineMethod
    //{
    //    public int Method(ref Vector X,ref Interval interval, Vector P,  Core ct_core, int max)
    //    {
    //        double b = (interval.a + interval.b) / 2, d, e = ct_core.eps;
    //        int k = 1;

    //        d = (ct_core.test_func.f(X + interval.a * P) * (b * b - interval.b * interval.b) + ct_core.test_func.f(X + b * P) * (interval.b * interval.b - interval.a * interval.a) + ct_core.test_func.f(X + interval.b * P) * (interval.a * interval.a - b * b)) /
    //            ((ct_core.test_func.f(X + interval.a * P) * (b - interval.b) + ct_core.test_func.f(X + b * P) * (interval.b - interval.a) + ct_core.test_func.f(X + interval.b * P) * (interval.a - b)) * 2);


    //        while (k < max && Math.Abs((b - d) / b) > e && (Math.Abs((ct_core.test_func.f(X + b * P) - ct_core.test_func.f(X + d * P)) / ct_core.test_func.f(X + b * P)) > e))
    //        {
    //            if (ct_core.test_func.f(X + b * P) > ct_core.test_func.f(X + d * P))
    //            {
    //                if (b < d)
    //                    interval.a= b;
    //                else
    //                   interval.b= b;
    //                b = d;
    //            }
    //            else
    //            {
    //                if (b < d)
    //                   interval.b= d;
    //                else
    //                    interval.a= d;
    //            }
    //            d = (interval.a + b) / 2 + (ct_core.test_func.f(X + interval.a * P) - ct_core.test_func.f(X + b * P)) * (ct_core.test_func.f(X + interval.a * P) - ct_core.test_func.f(X + b * P)) * (b - interval.b) * (interval.b - interval.a) /
    //                ((ct_core.test_func.f(X + interval.a * P) * (b - interval.b) + ct_core.test_func.f(X + b * P) * (interval.b - interval.a) + ct_core.test_func.f(X + interval.b * P) * (interval.a - b)) * 2);


    //            k++;
    //        }
    //        interval.a= b;
    //       interval.b= d;
    //        X = X + ((interval.a+ b) / 2) * P;
    //        return k;
    //    }
    //}
    //public class sven : ILineMethod
    //{
    //    private double _h=1;
    //    public int Method(ref Vector X, ref Interval interval, Vector P, Core ct_core, int max)
    //    {

    //        int k = 0;
    //        double h=_h;
    //        double x2 = h;
    //        double x1 = 0;
    //        if (ct_core.test_func.f(X + h * P) > ct_core.test_func.f(X))
    //        {
    //            h = -h;
    //            x2 = h;
    //        }
    //        double x3;
    //        while (true)
    //        {
    //            h = 2 * h;
    //            x3 = x2 + h;
    //            if (ct_core.test_func.f(X + x3 * P) > ct_core.test_func.f(X + x2 * P))
    //                break;
    //            x1 = x2;
    //            x2 = x3;
    //            k++;
    //        }
    //        if (x1 > x3)
    //        {
    //            interval.a= x3;
    //            interval.b = x1;
    //        }
    //        else
    //        {
    //           interval.a= x1;
    //           interval.b = x3;
    //        }
    //        return k;
    //    }
    //}
    //public class gold_section : ILineMethod
    //{
    //    public int Method(ref Vector X, ref Interval interval, Vector P, Core ct_core, int max)
    //    {
    //        double e = ct_core.eps/100;
    //        double sqrtt = Math.Sqrt(5.0) / 2;
    //        double t1 = sqrtt - 0.5; //0.6
    //        double t2 = 1.5 - sqrtt; //0.3
    //        double X1 = interval.a + t1 * Math.Abs(interval.a - interval.b);
    //        double X2 = interval.a + t2 * Math.Abs(interval.a - interval.b);
    //        int k = 0;
    //        while (Math.Abs(interval.b - interval.a) >= e && k < max)
    //        {
    //            if (ct_core.test_func.f(X + X2 * P) < ct_core.test_func.f(X + X1 * P))
    //            {
    //                interval.b = X1;
    //                X1 = X2;
    //                X2 = interval.a + t2 * (interval.b - interval.a);
    //            }
    //            else
    //            {
    //                interval.a = X2;
    //                X2 = X1;
    //                X1 = interval.a + t1 * (interval.b - interval.a);
    //            }
    //            k++;
    //        }

    //        X = X + ((interval.a + interval.b) / 2) * P;
    //        return k;
    //    }
    //}


}
