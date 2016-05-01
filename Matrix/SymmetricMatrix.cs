using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int dim) : base(dim)
        {}
    }
}
