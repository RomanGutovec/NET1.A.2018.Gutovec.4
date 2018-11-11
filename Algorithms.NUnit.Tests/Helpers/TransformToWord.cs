using Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.NUnit.Tests.Helpers
{
    public class TransformToWord : ITransform<double, string>
    {
        public string Transform(double source)
        {
            StringBuilder result = new StringBuilder();
            TransformerToWords.TransformerOneDoubleToWord(source.ToString(), result);
            return result.ToString();
        }
    }
}
