using Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class TransformerToIEEE : ITransform<double, string>
    {
        public string Transform(double source)
        => source.GetStringviewOfDouble();
    }
}
