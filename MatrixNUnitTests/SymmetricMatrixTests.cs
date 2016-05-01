using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using NUnit.Framework;

namespace MatrixNUnitTests
{
    class SymmetricMatrixTests
    {
        #region Fields
        private SymmetricMatrix<string> matrix;
        #endregion

        #region GetIndexer Tests
        public IEnumerable<TestCaseData> IndexerTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(1, 1).Returns(5.ToString());
                yield return new TestCaseData(3, 2).Returns(14.ToString());
                yield return new TestCaseData(2,3).Returns(14.ToString());

            }
        }

        [Test, TestCaseSource(nameof(IndexerTestCaseDatas))]
        public string IndexerTests(int row, int col)
        {
            SetMatrix(4);
            return matrix[row, col];
        }
        #endregion

        
        #region Private Methods
        private void SetMatrix(int dim)
        {
            matrix = new SymmetricMatrix<string>(dim);
            int k = 0;
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                {
                    matrix[i, j] = k.ToString();
                    k++;
                }

        }
        #endregion
    }
}
