using System;
using System.Text.RegularExpressions;

namespace Matrix_Calculator {
     class Matrix {
        public double[,] MainMatrix { get; set; }
        public int Rows { get;  set; }
        public int Cols { get;  set; }

        public Matrix(double[,] matrix) {
            MainMatrix = matrix;
            Rows = MainMatrix.GetLength(0);
            Cols = MainMatrix.GetLength(1);
        }

        public Matrix(int a, int b) {
            MainMatrix = new double[a, b];
            Rows = MainMatrix.GetLength(0);
            Cols = MainMatrix.GetLength(1);
        }

        public Matrix(int a) {
            MainMatrix = new double[a, a];
            Rows = MainMatrix.GetLength(0);
            Cols = MainMatrix.GetLength(1);
        }

        public Matrix(string matrixString) {
            MainMatrix = ReadMatrix(matrixString);
            Rows = MainMatrix.GetLength(0);
            Cols = MainMatrix.GetLength(1);
        }

        private bool IsSquare() {
            return (Rows == Cols);
        }
        private bool IsSquare(double[,]matrix) {
            return (matrix.GetLength(0) == matrix.GetLength(1));
        }
        public double MaxValue() {
            double temp = MainMatrix[0, 0];
            for (int i = 0; i < MainMatrix.GetLength(0); i++) {
                for (int j = 0; j < MainMatrix.GetLength(1); j++) {
                    if (MainMatrix[i, j] >= temp) {
                        temp = MainMatrix[i, j];
                    }
                }
            }
            return temp;
        }
        public double MinValue() {
            double temp = MainMatrix[0, 0];
            for (int i = 0; i < MainMatrix.GetLength(0); i++) {
                for (int j = 0; j < MainMatrix.GetLength(1); j++) {
                    if (MainMatrix[i, j] <= temp) {
                        temp = MainMatrix[i, j];
                    }
                }
            }
            return temp;
        }
        public string Dimension() {
            return string.Format(" {0}*{1}", MainMatrix.GetLength(0), MainMatrix.GetLength(1));
        }

        public double Trace() {
            if (MainMatrix.GetLength(0) != MainMatrix.GetLength(1))
                throw new Exception("ERROR: This is not Square MainMatrix");
            double trace = 0;
            for (int i = 0; i < MainMatrix.GetLength(0); i++) {
                for (int j = 0; j < MainMatrix.GetLength(1); j++) {
                    if (i == j)
                        trace += MainMatrix[i, j];
                }
            }
            return trace;
        }

        public override string  ToString() {
            string matString = null;
            for (int i = 0; i < MainMatrix.GetLength(0); i++) {
                matString += Environment.NewLine;
                for (int j = 0; j < MainMatrix.GetLength(1); j++) {
                    matString += MainMatrix[i, j] + " ";
                }
            }
            return matString;
        }

        public  static string ToString(double[,]matrix) {
            string matString = null;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                matString += Environment.NewLine;
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    matString += matrix[i, j] + " ";
                }
            }
            return matString;
        }
        
        private double[,] ReadMatrix(string matrixStr) {
            string[] lines = matrixStr.Trim().Split('\n');
            string[] rows = Regex.Replace(lines[0], @" +", @" ").Trim().Split(' ', '\t');
            
            double[,] matrix = new double[lines.Length, rows.Length];
            for (int i = 0; i < lines.Length; i++) {
                rows = Regex.Replace(lines[i], @" +", @" ").Trim().Split(' ', '\t');
                for (int j = 0; j < rows.Length; j++) {
                    matrix[i, j] = Convert.ToDouble(rows[j]);
                }
            }
            return matrix;
        }

        
        public  double[,] Transpose() {
            double[,] transp = new double[Cols, Rows];
            for (int i = 0; i < transp.GetLength(0); i++) {
                for (int j = 0; j < transp.GetLength(1); j++) {
                    transp[i, j] = MainMatrix[j, i];
                }
            }
            return transp;
        }
        public static double[,] Transpose(double[,]matrix) {
            double[,] transp = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < transp.GetLength(0); i++) {
                for (int j = 0; j < transp.GetLength(1); j++) {
                    transp[i, j] = matrix[j, i];
                }
            }
            return transp;
        }

        public static double Determ(double[,] matrix) {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new Exception("ERROR: This is not Square !!!");
            double det = 0;
            int Rank = matrix.GetLength(0);
            if (Rank == 1)
                det = matrix[0, 0];
            if (Rank == 2)
                det = matrix[0, 0]*matrix[1, 1] - matrix[0, 1]*matrix[1, 0];
            if (Rank > 2) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    det += Math.Pow(-1, 0 + j)*matrix[0, j]*Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }
        public double Determ() {
            if (!IsSquare())
                throw new Exception("ERROR: This is not Square!!!");
            double det = 0;
            int Rank = MainMatrix.GetLength(0);
            if (Rank == 1)
                det = MainMatrix[0, 0];
            if (Rank == 2)
                det = MainMatrix[0, 0] * MainMatrix[1, 1] - MainMatrix[0, 1] * MainMatrix[1, 0];
            if (Rank > 2) {
                for (int j = 0; j < MainMatrix.GetLength(1); j++) {
                    det += Math.Pow(-1, 0 + j) * MainMatrix[0, j] * Determ(GetMinor(MainMatrix, 0, j));
                }
            }
            return det;
        }
        private static double[,] GetMinor(double[,] matrix, int row, int column) {
            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if ((i != row) || (j != column)) {
                        if (i > row && j < column)
                            buf[i - 1, j] = matrix[i, j];
                        if (i < row && j > column)
                            buf[i, j - 1] = matrix[i, j];
                        if (i > row && j > column)
                            buf[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column)
                            buf[i, j] = matrix[i, j];
                    }
                }
            return buf;
        }

        public double[,] Invert() {
            if (!IsSquare()) {
                throw new Exception("ERROR: This is not Square !!!");
            }
            
            int det = (int) Determ(MainMatrix);
            if (det == 0) {
                throw new Exception("ERROR: Determinant is 0, so inverted matrix can`t be created!!!");
            }
            double detOne = Math.Round(((double) 1/det), 3);
            double[,] invMatrix = MatrixEditor.Multiplication(Transpose(Adjugate(MainMatrix)), detOne);
            return invMatrix;
        }

        public double[,] Adjugate() {
            if (!IsSquare()) {
                throw new Exception("ERROR: This is not Square !!!");
            }
            double[,] adj = new double[Rows,Rows];
            double[,] minor = new double[Rows - 1, Rows - 1];
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Rows; j++) {
                    minor = GetMinor(MainMatrix, i, j);
                    if ((j + i)%2 == 0)
                        adj[i, j] = Determ(minor);
                    else
                        adj[i, j] = -Determ(minor);
                }
            }
            return adj;
        }
        public double[,] Adjugate(double[,]matrix) {
            if (!IsSquare(matrix)) {
                throw new Exception("ERROR: This is not Square !!!");
            }
            double[,] adj = new double[Rows, Rows];
            double[,] minor = new double[Rows - 1, Rows - 1];
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Rows; j++) {
                    minor = GetMinor(matrix, i, j);
                    if ((j + i) % 2 == 0)
                        adj[i, j] = Determ(minor);
                    else
                        adj[i, j] = -Determ(minor);
                }
            }
            return adj;
        }
        public int Rank() {
            int rang = 0;
            int q = 1;
            
            while (q <= MinValue(MainMatrix.GetLength(0), MainMatrix.GetLength(1))) {
                Matrix matbv = new Matrix(q, q);
                for (int i = 0; i < (MainMatrix.GetLength(0) - (q - 1)); i++) {
                    for (int j = 0; j < (MainMatrix.GetLength(1) - (q - 1)); j++) {
                        for (int k = 0; k < q; k++) {
                            for (int c = 0; c < q; c++) {
                                matbv.MainMatrix[k, c] = MainMatrix[i + k, j + c];
                            }
                        }

                        if (Determ(matbv.MainMatrix) != 0) {
                            rang = q;
                        }
                    }
                }
                q++;
            }

            return rang;
        }

        public  double[,] LUmatrix(int matrLU) {
            if (!IsSquare()) {
                throw new Exception("ERROR: This is not Square !!!");
            }
            int size = MainMatrix.GetLength(0);
            double[,] L = new double[size, size];
            double[,] U = new double[size, size];
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    U[0, i] = MainMatrix[0, i];
                    L[i, 0] = MainMatrix[i, 0]/U[0, 0];
                    double sum = 0;
                    for (int k = 0; k < i; k++) {
                        sum += L[i, k]*U[k, j];
                    }
                    U[i, j] = Math.Round(MainMatrix[i, j] - sum, 2);
                    if (i > j) {
                        L[j, i] = 0;
                    }
                    else {
                        sum = 0;
                        for (int k = 0; k < i; k++) {
                            sum += L[j, k]*U[k, i];
                        }
                        L[j, i] = Math.Round((MainMatrix[j, i] - sum)/U[i, i], 2);
                    }
                }
            }
            if (matrLU == 0) {
                return L;
            }
            return U;
        }


        private int MinValue(int a, int b) {
            if (a >= b)
                return b;
            return a;
        }
    }
}
