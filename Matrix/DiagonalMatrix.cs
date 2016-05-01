using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Constructors
        public DiagonalMatrix(int dim) : base(dim)
        {}
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
                return matrix[indexColumn + indexRow * dim];
            }
            set
            {
                CheckRef(value);
                if (indexColumn == indexRow)
                    matrix[indexColumn + indexRow * dim] = value;
                this.MakeChange(indexRow, indexColumn, this);
            }
        }

        public T this[int index]
        {
            get { return this[index, index]; }
            set
            {
                this[index, index] = value;
                this.MakeChange(index, index, this);
            }
        }
        #endregion


    }
}
