using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.NUnit.Tests.Helpers
{
    public class PredicatesForDigits
    {
        public bool IsContainsOne(int number)

           => number.ToString().Contains('1');

        public bool IsSimple(int number)
        {
            bool isNotSimpleFlag = false;
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    isNotSimpleFlag = true;
                    break;
                }
            }

            return !isNotSimpleFlag;
        }

        public bool IsEven(int number)
         => number % 2 == 0;
    }
}