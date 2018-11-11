using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Interfaces
{
    public interface ITransform<in TInput, out TOutput>
    {
        TOutput Transform(TInput source);
    }
}
