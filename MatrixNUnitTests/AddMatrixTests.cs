using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using NUnit.Framework;

namespace MatrixNUnitTests
{
    class AddMatrixTests
    {
        #region Fields
        private SquareMatrix<string> matrix;
        private SquareMatrix<string> matrixSum;
        #endregion

        #region GetIndexer Tests
        public IEnumerable<TestCaseData> AddCaseDatas
        {
            get
            {
                yield return new TestCaseData().Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(AddCaseDatas))]
        public bool AddTests()
        {
            SetMatrix(4);
            SquareMatrix<string> newMatrix = matrix.SumMatrix(matrix) as SquareMatrix<string>;
            return Equals(matrixSum, newMatrix);
        }
        #endregion


        #region Private Methods

        private bool Equals(MatrixClass<string> first, MatrixClass<string> second)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!first[i, j].Equals(second[i, j]))
                        return false;
                }
            }
            return true;
        }

        private void SetMatrix(int dim)
        {
            matrix = new SquareMatrix<string>(dim);
            matrixSum = new SquareMatrix<string>(dim);
            int k = 0;
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                {
                    matrix[i, j] = k.ToString();
                    matrixSum[i, j] = k.ToString() + k.ToString();
                    k++;
                }
            }
        #endregion
    }
}

