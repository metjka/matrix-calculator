using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Matrix_Calculator {
     class MatrixEditor {


        public static double[,] Multiplication(double[,] matrixA, double[,] matrixB) {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
                throw new Exception("ERROR!!! Can`t multiply these matrices!!!");
            double[,] matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++) {
                for (int j = 0; j < matrixB.GetLength(1); j++) {
                    for (int k = 0; k < matrixB.GetLength(0); k++) {
                        matrixC[i, j] += Math.Round((matrixA[i, k] * matrixB[k, j]),2);
                    }
                }
            }
            return matrixC;
        }

        public static double[,] Multiplication(double[,] matrix, double X) {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    matrix[i, j] = matrix[i, j]*X;
                }
            }
            return matrix;
        }
        public static double[,] Power(double[,] A,  int pow) {
            if (A.GetLength(0) != A.GetLength(1))
                throw new Exception("ERROR: This is not Square MainMatrix");
            

            int rank = A.GetLength(0);
            double[,] C = A;
            for (int p = 0; p < pow - 1; p++) {
                double[,] B = new double[rank, rank];
                for (int i = 0; i < rank; i++)
                    for (int j = 0; j < rank; j++) {
                        for (int k = 0; k < rank; k++)
                            B[i, j] += C[i, k] * A[k, j];
                    }
                C = B;
            }
            return C;
        }
        public static double[,] Addition(double[,] matrixA, double[,]matrixB) {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) | matrixA.GetLength(1) != matrixB.GetLength(1)) {
                throw new Exception("ERROR!!! Can`t summarize these matrices!!!");
            }
            double[,] matrixC = new double[matrixA.GetLength(0), matrixA.GetLength(0)];
            for (int i = 0; i < matrixA.GetLength(0); i++) {
                for (int j = 0; j < matrixA.GetLength(0); j++) {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];

                }
            }
            return matrixC;
        }
        public static double[,] Subtraction(double[,] matrixA, double[,] matrixB) {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) | matrixA.GetLength(1) != matrixB.GetLength(1)) {
                throw new Exception("ERROR!!! Can`t subtract these matrices!!!");
            }
            double[,] matrixC = new double[matrixA.GetLength(0), matrixA.GetLength(0)];
            for (int i = 0; i < matrixA.GetLength(0); i++) {
                for (int j = 0; j < matrixA.GetLength(0); j++) {
                    matrixC[i, j] = matrixA[i, j] - matrixB[i, j];

                }
            }
            return matrixC;
        }
        
    }
       
    
}

