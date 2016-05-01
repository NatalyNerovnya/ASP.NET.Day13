using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class CheckParameters
    {
        protected void CheckRef(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException();
        }

        //protected void CheckDouble(double x)
        //{
        //    if (Double.IsInfinity(x) || Double.IsNaN(x))
        //        throw new ArgumentException();
        //}

        protected void CheckPositive(double x)
        {
            if (x <= 0)
                throw new ArgumentException();
        }

        protected void CheckNotNegative(double x)
        {
            if (x < 0)
                throw new ArgumentException();
        }
    }
}
