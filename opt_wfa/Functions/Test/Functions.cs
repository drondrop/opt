using opt_wfa.Data_Types;
using opt_wfa.Factory;

namespace opt_wfa.Functions.Test
{
    
    public class f11 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { -1, 0 })); } }
        public double f(Vector X)
        {
            return 100 * (X[1] - X[0] * X[0]) * (X[1] - X[0] * X[0]) + (1 - X[0]) * (1 - X[0]);
        }
    }
    public class f10 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 1, 1 })); } }
        public double f(Vector X)
        {
            return X[0] * X[0] + 3 * X[1] * X[1] + 2 * X[0] * X[1];
        }
    }
    public class f19 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 1.5, 2 })); } }
        public double f(Vector X)
        {
            return 100 * (X[1] - X[0] * X[0]) * (X[1] - X[0] * X[0]) + (1 - X[0]) * (1 - X[0]);
        }
    }
   
    public class f23 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { -1.2, 1 })); } }
        public double f(Vector X)
        {
            return (X[1] - X[0] * X[0]) * (X[1] - X[0] * X[0]) + (1 - X[0]) * (1 - X[0]);
        }
    }
    public class f24 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 1.5, 2 })); } }
        public double f(Vector X)
        {
            return (X[1] - X[0] * X[0]) *
                   (X[1] - X[0] * X[0]) + 100*(1 - X[0]*X[0]) * (1 - X[0]*X[0]);
        }
    }
    public class f25 : iFunc
    {
        public int arguments { get { return 3; } }
        public Vector X_0 { get { return new Vector((new double[] { 2, -2,-2 })); } }
        public double f(Vector X)
        {
            return 3 * (X[0] - 4) * (X[0] - 4) + 5 * (X[1] + 3) * (X[1] + 3) + 7 * (2 * X[2] + 1) * (2 * X[2] + 1);
        }
    }
 public class f26 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 1, 2 })); } }
        public double f(Vector X)
        {
            return X[0] * X[0] * X[0] + X[1] * X[1] - 3 * X[0] - 2 * X[1] + 2;
        }
    }
    public class f27 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 1, 0 })); } }
        public double f(Vector X)
        {
            return -12 * X[1] + 4 * X[0] * X[0] + 4 * X[1] * X[1] - 4 * X[0] * X[1];
        }
    }
    public class f29 : iFunc
    {
        public int arguments { get { return 3; } }
        public Vector X_0 { get { return new Vector((new double[] { -5, 4,2 })); } }
        public double f(Vector X)
        {
            return (X[0] *  X[1] * X[2] - 1) * (X[0] * X[1] * X[2] - 1)
                     + 5 * (X[2] * (X[0] + X[1]) - 2) * (X[2] * (X[0] + X[1]) - 2)
                     + 2 * (X[0] + X[1] + X[2] - 3) * (X[0] + X[1] + X[2] - 3);

        }
    }
}
public class f20 : iFunc
    {
        public int arguments { get { return 3; } }
        public Vector X_0 { get { return new Vector((new double[] { 4, -1,2 })); } }
        public double f(Vector X)
        {
            return (X[0] - 1) *(X[0] - 1) 
                + (X[1] - 3)*(X[1] - 3)
                + 4*(X[2]+5) * (X[2]+5);
        }
    }
 public class f21 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 10, 10 })); } }
        public double f(Vector X)
        {
            return 8 * (X[0] * X[0] ) + 4*(X[1] * X[0] ) + 5*(X[1]*X[1]);
        }
    }
public class f22 : iFunc
    {
        public int arguments { get { return 2; } }
        public Vector X_0 { get { return new Vector((new double[] { 8, 9 })); } }
        public double f(Vector X)
        {
            return 4 * (X[0] -5 )*(X[0] -5 ) +
                        (X[1] -6 )*(X[1] -6 ) ;
        }
    }






