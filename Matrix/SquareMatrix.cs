using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : MatrixClass<T>
    {
        #region Constructors
        public SquareMatrix(int dim) : base(dim)
        { }
        #endregion

        #region Indexer
        public override T this[int indexRow, int indexColumn]
        {
            get
            {
                CheckNotNegative(indexRow);
                CheckNotNegative(indexColumn);
                if (indexRow >= dim || indexColumn >= dim)
                    throw new ArgumentException();
                return matrix[indexColumn + indexRow *dim];
            }
            set
            {
                CheckRef(value);
                matrix[indexColumn + indexRow * dim] = value;
                this.MakeChange(indexColumn, indexRow, this);
            }
        }
        #endregion
    }
}
