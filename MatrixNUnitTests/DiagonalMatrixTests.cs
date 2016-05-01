using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using NUnit.Framework;

namespace MatrixNUnitTests
{
    class DiagonalMatrixTests
    {
        #region Fields
        private DiagonalMatrix<double> matrix;
        #endregion

        #region GetIndexer Tests
        public IEnumerable<TestCaseData> IndexerTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(1, 1).Returns(5.0);
                yield return new TestCaseData(3, 2).Returns(0.0);
                yield return new TestCaseData(-4, 1).Throws(typeof(ArgumentException));
                yield return new TestCaseData(1, 12).Throws(typeof(ArgumentException));
            }
        }

        [Test, TestCaseSource(nameof(IndexerTestCaseDatas))]
        public double IndexerTests(int row, int col)
        {
            SetMatrix(4);
            return matrix[row, col];
        }
        #endregion

        #region SetIndexer Tests
        public IEnumerable<TestCaseData> IndexerSetTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(0, 0, 4.0).Returns(true);
                yield return new TestCaseData(3, 2, 4.0).Returns(false);
            }
        }

        [Test, TestCaseSource(nameof(IndexerSetTestCaseDatas))]
        public bool IndexerSetTests(int row, int col, double value)
        {
            matrix = new DiagonalMatrix<double>(4);
            matrix[row, col] = value;
            return matrix[row, col] == value;
        }
        #endregion

        #region GetIndexer with 1 pararmetr Tests
        public IEnumerable<TestCaseData> IndexerOneTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(1).Returns(5.0);
                yield return new TestCaseData(3).Returns(15.0);
            }
        }

        [Test, TestCaseSource(nameof(IndexerOneTestCaseDatas))]
        public double IndexerOneTests(int index)
        {
            SetMatrix(4);
            return matrix[index];
        }
        #endregion

        #region SetIndexer with 1 pararmetr Tests
        public IEnumerable<TestCaseData> IndexerOneSetTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(0, 4.0).Returns(true);
                yield return new TestCaseData(3, 4.0).Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(IndexerOneSetTestCaseDatas))]
        public bool IndexerOneSetTests(int index, double value)
        {
            matrix = new DiagonalMatrix<double>(4);
            matrix[index] = value;
            return matrix[index] == value;
        }
        #endregion

        #region Private Methods
        private void SetMatrix(int dim)
        {
            matrix = new DiagonalMatrix<double>(dim);
            double k = 0.0;
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                {
                    matrix[i, j] = k;
                    k++;
                }

        }
        #endregion
    }
}
