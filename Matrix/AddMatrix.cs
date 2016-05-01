using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Class provading extension method for summing matrix
    /// </summary>
    public static class AddMatrix
    {
        #region Public Methods
        /// <summary>
        /// Method for counting sum of two matrix
        /// </summary>
        /// <typeparam name="T">Type of elements in matrix</typeparam>
        /// <param name="matrix">First matrix</param>
        /// <param name="otherMatrix">Second matrix</param>
        /// <returns>Sum matrix</returns>
        public static MatrixClass<T> SumMatrix<T>(this MatrixClass<T> matrix, MatrixClass<T> otherMatrix)
        {
            if (typeof(T) == typeof(String))
                return (MatrixClass<T>)(object)SumStrings(matrix, otherMatrix);
            else
                return SumAll(matrix, otherMatrix);
        }
        #endregion

        #region Private Methods
        private static Func<T, T, T> CreateAdd<T>()
        {
            ParameterExpression lhs = Expression.Parameter(typeof(T), "lhs");
            ParameterExpression rhs = Expression.Parameter(typeof(T), "rhs");

            Expression<Func<T, T, T>> addExpr = Expression<Func<T, T, T>>.
            Lambda<Func<T, T, T>>(Expression.Add(lhs, rhs), new ParameterExpression[] { lhs, rhs });

            Func<T, T, T> addMethod = addExpr.Compile();

            return addMethod;
        }

        private static MatrixClass<string> SumStrings<T>(MatrixClass<T> matrix, MatrixClass<T> otherMatrix)
        {
            int size = (int)Math.Pow(matrix.GetMatrix().Length, 0.5);
            MatrixClass<string> newMatrix = new SquareMatrix<string>(size);
            if (typeof(T) == typeof(String))
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        newMatrix[i, j] = matrix[i, j].ToString() + otherMatrix[i, j].ToString();
                    }
                }
            return newMatrix;
        }

        private static MatrixClass<T> SumAll<T>(MatrixClass<T> matrix, MatrixClass<T> otherMatrix)
        {
            int size = (int)Math.Pow(matrix.GetMatrix().Length, 0.5);
            MatrixClass<T> newMatrix = new SquareMatrix<T>(size);
            Func<T, T, T> addMethod = CreateAdd<T>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newMatrix[i, j] = addMethod(matrix[i, j], otherMatrix[i, j]);
                }
            }
            return newMatrix;
        }
        #endregion
    }
}
