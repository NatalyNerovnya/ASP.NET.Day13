using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public abstract class CheckParameters
    {
        protected void CheckRef(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException();
        }

    }
}
