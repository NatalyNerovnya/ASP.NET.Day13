using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public sealed class ChangeMatrixEventArgs<T> : EventArgs
    {
        #region Fields

        private readonly int indexRow;
        private readonly int indexColumn;
        private MatrixClass<T> matrix;

        #endregion

        #region Properties

        public int IndexRow { get { return indexRow; } }
        public int IndexColumn { get { return indexColumn; } }

        public MatrixClass<T> Matrix
        {
            get { return matrix; }
            set
            {
                if(ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                matrix = value;
            }
        }

        #endregion

        #region Constructor

        public ChangeMatrixEventArgs(int indexRow, int indexColumn, MatrixClass<T> matr)
        {
            if(indexRow < 0 || indexColumn < 0)
                throw new ArgumentException();
            this.indexRow = indexRow;
            this.indexColumn = indexColumn;
            Matrix = matr;
        }

        #endregion

    }
}
