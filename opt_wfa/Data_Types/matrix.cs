using System;

namespace opt_wfa.Data_Types
{


   
    public class Matrix
    {
        private int rowsCount;
        private int columnsCount;
        private double[] matr;
        private bool error;
        //геттеры
        public bool GetError()
        {
            return error;
        }
        public int RowCount()
        {
            return rowsCount;
        }
        public int ColumnCount()
        {
            return columnsCount;
        }
        public double GetItem(int n, int m)
        {
            return matr[n * columnsCount + m];
        }
        //сеттеры
        public void SetItem(int n, int m, double newItem)
        {
            matr[n * columnsCount + m] = newItem;
        }
        //конструкторы
        public Matrix(Matrix old)
        {
            this.rowsCount = old.rowsCount;
            this.columnsCount = old.columnsCount;
            this.error = old.error;
            this.matr = new double[this.rowsCount * this.columnsCount];
            for (int i = 0; i < this.rowsCount * this.columnsCount; i++) this.matr[i] = old.matr[i];
        }
        public Matrix(int _rowsCount, int _columnsCount)
        {
            this.matr = new double[_rowsCount * _columnsCount];
            this.rowsCount = _rowsCount;
            this.columnsCount = _columnsCount;
            for (int i = 0; i < _rowsCount * _columnsCount; i++)
            {
                matr[i] = 0;
            }
            this.error = false;
        }
        public string printMatrix()
        {
            string tmp = "";
            if (this.ColumnCount() == 1 && this.RowCount() > 1)
            {
                tmp += "\t{";
                for (int i = 0; i < this.RowCount(); i++)
                {
                    tmp += rP(this.GetItem(i, 0), 2) + "\t";
                }
                tmp += "}T\r\n";
            }
            else
            {
                tmp += "\t{\r\n";
                for (int j = 0; j < this.ColumnCount(); j++)
                {

                    for (int i = 0; i < this.RowCount(); i++)
                    {
                        tmp += "\t" + rP(this.GetItem(j, i), 2) + ";\t";
                    }
                    tmp += "\r\n";
                }
                tmp += "\t}";
                tmp += "\r\n";
            }
            return tmp;
        }
        private double rP(double input, int rad)
        {
            if (input != 0)
            {
                double pows = Math.Pow(10, rad);
                pows = pows * input;
                input = Math.Round(pows, 1) / Math.Pow(10, rad);
                return input;
            }
            else
            {
                return 0;
            }
        }
        //перегруженные опирации
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.rowsCount, B.columnsCount);
            int rA = A.rowsCount, rB = B.rowsCount, cB = B.columnsCount;
            if (A.columnsCount != B.rowsCount)
            {
                C.error = true;
                return C;
            }
            for (int row = 0; row < rA; row++)
            {
                for (int col = 0; col < cB; col++)
                {
                    double tmpItem = 0;
                    for (int inner = 0; inner < rB; inner++)
                    {
                        tmpItem += A.GetItem(row, inner) * B.GetItem(inner, col);
                    }
                    C.SetItem(row, col, tmpItem);
                }
            }
            return C;
        }
        public static Matrix operator *(double b, Matrix A)
        {
            Matrix C = new Matrix(A.rowsCount, A.columnsCount);
            int rA = A.rowsCount, cA = A.columnsCount;

            for (int i = 0; i < rA * cA; i++)
            {
                C.matr[i] = A.matr[i] * b;
            }
            return C;
        }
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.rowsCount, A.columnsCount);
            int rA = A.rowsCount, cA = B.columnsCount;
            if (A.columnsCount != B.columnsCount || A.rowsCount != B.rowsCount)
            {
                C.error = true;
                return C;
            }
            for (int row = 0; row < rA; row++)
            {
                for (int col = 0; col < cA; col++)
                {
                    C.SetItem(row, col, A.GetItem(row, col) + B.GetItem(row, col));
                }
            }
            return C;
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.rowsCount, A.columnsCount);
            int rA = A.rowsCount, cA = A.columnsCount;
            if (A.columnsCount != B.columnsCount || A.rowsCount != B.rowsCount)
            {
                C.error = true;
                return C;
            }
            for (int row = 0; row < rA; row++)
            {
                for (int col = 0; col < cA; col++)
                {
                    C.SetItem(row, col, A.GetItem(row, col) - B.GetItem(row, col));
                }
            }
            return C;
        }
        public static Matrix operator /(Matrix A, double b)
        {
            Matrix C = new Matrix(A.rowsCount, A.columnsCount);
            int count = A.rowsCount * A.columnsCount;
            if (b == 0)
            {
                C.error = true;
                return C;
            }
            for (int row = 0; row < count; row++)
            {
                C.matr[row] = A.matr[row] / b;
            }
            return C;
        }
        public Matrix Transparate()
        {
            int rc = this.rowsCount, cc = this.columnsCount;
            Matrix C = new Matrix(cc, rc);
            for (int row = 0; row < rc; row++)
            {
                for (int col = 0; col < cc; col++)
                {
                    C.SetItem(col, row, this.GetItem(row, col));
                }
            }
            return C;
        }
    }


}
