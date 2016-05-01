using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region Constructors
        public SymmetricMatrix(int dim) : base(dim)
        {}
        #endregion
    }
}
