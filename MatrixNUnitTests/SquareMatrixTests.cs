using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using NUnit.Framework;

namespace MatrixNUnitTests
{
    public class SquareMatrixTests
    {
        #region Fields
        private SquareMatrix<int> sqIntMatrix;
        #endregion
        
        #region GetIndexer Tests
        public IEnumerable<TestCaseData> IndexerTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(1,1).Returns(5);
                yield return new TestCaseData(3,3).Returns(15);
                yield return new TestCaseData(-4,1).Throws(typeof(ArgumentException));
                yield return new TestCaseData(1,12).Throws(typeof(ArgumentException));
            }
        }

        [Test, TestCaseSource(nameof(IndexerTestCaseDatas))]
        public int IndexerTests(int row, int col)
        {
            SetMatrix(4);
            return sqIntMatrix[row,col];
        }
        #endregion

        #region SetIndexer Tests
        public IEnumerable<TestCaseData> IndexerSetTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(0,0,4).Returns(true);
                yield return new TestCaseData(3, 3, 4).Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(IndexerSetTestCaseDatas))]
        public bool IndexerSetTests(int row, int col, int value)
        {
            sqIntMatrix = new SquareMatrix<int>(4);
            sqIntMatrix[row, col] = value;
            return sqIntMatrix[row, col] == value;
        }
        #endregion

        #region Private Methods
        private void SetMatrix(int dim)
        {
            sqIntMatrix = new SquareMatrix<int>(dim);
            for (int i = 0, k = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                {
                    sqIntMatrix[i, j] = k;
                    k++;
                }

        }
        #endregion

    }
}
