using opt_wfa.Methods.Gen;
using System;

namespace opt_wfa.Data_Types
{
    public class Vector
    {
        private double[] _array;
        private int _count;
        private bool _isRow;

        public double[] Array { get { return _array; } }

        public Vector(int length)
        {
            this._array = new double[length];

            this._count = length;
            this._isRow = false;
            for (int i = 0; i < _count; i++) _array[i] = 0;
        }

        public Vector(int length,RandomHelper rnd,int expand)
        {
            this._array = new double[length];

            this._count = length;
            this._isRow = false;
            for (int i = 0; i < _count; i++) _array[i] = rnd.nextDouble() * expand - expand/2;
        }
        public Vector(double[] array)
        {
            this._array = new double[array.Length];

            this._count = array.Length;
            this._isRow = false;
            for (int i = 0; i < _count; i++) _array[i] = array[i];
        }
        public Vector(Vector B)
        {
            this._array = new double[B._count];
            this._count = B._count;
            this._isRow = B._isRow;
            for (int i = 0; i < _count; i++) this._array[i] = B._array[i];
        }
        public bool isRow
        {
            get { return _isRow; }
        }
        public bool isColumn
        {
            get { return !(_isRow); }
        }
        public int length
        {
            get { return _count; }
        }
        public double this[int number]
        {
            get { return _array[number]; }
            set { _array[number] = value; }
        }
        public Vector trans()
        {

            return new Vector(this)
            {
                _isRow = !this._isRow
            };
        }

        public static Vector operator +(Vector A, Vector B)
        {
            if (A._count == B._count)
            {
                if (A._isRow == B._isRow)
                {
                    Vector C = new Vector(A._count);
                    C._isRow = A._isRow;
                    for (int i = 0; i < A._count; i++) C._array[i] = A._array[i] + B._array[i];
                    return C;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }

        }
        public static Vector operator -(Vector A, Vector B)
        {
            if (A._count == B._count)
            {
                if (A._isRow == B._isRow)
                {
                    Vector C = new Vector(A._count);
                    C._isRow = A._isRow;
                    for (int i = 0; i < A._count; i++) C._array[i] = A._array[i] - B._array[i];
                    return C;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }

        }
        public static dynamic operator *(Vector A, Vector B)
        {
            if (A._isRow != B._isRow)
            {
                if (A._isRow)
                {
                    if (A._count == B._count)
                    {
                        double result = 0;
                        for (int i = 0; i < A._count; i++) result += A._array[i] * B._array[i];
                        return result;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    Matrix result = new Matrix(A._count, B._count);
                    for (int i = 0; i < A._count; i++)
                        for (int j = 0; j < B._count; j++)
                            result.SetItem(i, j, A._array[i] * B._array[j]);
                    return result;
                }
            }
            else
            {
                throw new Exception();
            }
        }
        public static Vector operator *(Vector A, double B)
        {
            Vector C = new Vector(A);
            for (int i = 0; i < C._count; i++)
                C._array[i] *= B;
            return C;
        }
        public static Vector operator *(double B, Vector A)
        {
            Vector C = new Vector(A);
            for (int i = 0; i < C._count; i++)
                C._array[i] *= B;
            return C;
        }
        public static Vector operator /(Vector A, double B)
        {
            Vector C = new Vector(A);
            for (int i = 0; i < C._count; i++)
                C._array[i] /= B;
            return C;
        }

        public double norm()
        {
            double norma = 0;
            for (int i = 0; i < this._count; i++)
            {
                norma += this._array[i] * this._array[i];
            }
            return Math.Sqrt(norma);
        }

        public  string ToString(int r=8)
        {
            string format = "N12";
            string vector = "";
            vector += "( ";
            if (_count != 0)
                vector += _array[0].ToString(format);
            for (int i = 1; i < _count; i++)
            {
                vector += "; " + _array[i].ToString(format);
            }
            vector += ")";
            return vector;
        }

    }
}
