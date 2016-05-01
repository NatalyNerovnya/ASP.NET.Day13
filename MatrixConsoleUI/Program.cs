using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace MatrixConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<string> sqm = new SquareMatrix<string>(3);
            sqm[0, 0] = 0.ToString();
            sqm[0, 1] = 1.ToString();
            sqm[0, 2] = 2.ToString();
            sqm[1, 0] = 3.ToString();
            sqm[1, 1] = 4.ToString();
            sqm[1, 2] = 5.ToString();
            sqm[2, 0] = 6.ToString();
            sqm[2, 1] = 7.ToString();
            sqm[2, 2] = 8.ToString();
            Show(3, 3, sqm);
            Console.WriteLine();
            DiagonalMatrix<int> dm = new DiagonalMatrix<int>(3);
            dm[0, 0] = 1;
            dm[0, 1] = 3;
            dm[1] = 2;
            dm[2] = 3;
            Show(3,3,dm);
            Console.WriteLine();
            SymmetricMatrix<int> sm = new SymmetricMatrix<int>(3);
            sm[0, 0] = 0;
            sm[0, 1] = 1;
            sm[0, 2] = 2;
            sm[1, 0] = 3;
            sm[1, 1] = 4;
            sm[1, 2] = 5;
            sm[2, 0] = 6;
            sm[2, 1] = 7;
            sm[2, 2] = 8;
            Show(3,3,sm);
            Console.WriteLine();
            MatrixClass<string> sumMatr = sqm.SumMatrix(sqm);
            Show(3, 3, sumMatr);
            
            Console.ReadKey();
        }

        private static void Show<T>(int col, int row, MatrixClass<T> matrix)
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }

    }
