using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.NUnit.Tests.Helpers
{
    public class PredicatesForStrings
    {
        public bool IsMatchLengthFive(string number)
             => number.Length == 5;

        public bool IsMatchReg(string sourceString, Regex regExpression)
        {
            MatchCollection matches = regExpression.Matches(sourceString);
            return matches.Count > 0;            
        }
    }
}
