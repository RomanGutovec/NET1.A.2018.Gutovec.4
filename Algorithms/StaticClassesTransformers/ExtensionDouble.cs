using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Class involves extension method for System.Double class
    /// </summary>
    public static class ExtensionDouble
    {
        private static readonly int doubleLengthInBits = 64;

        /// <summary>
        /// Convert number with floating point in byte view
        /// </summary>
        /// <param name="number">source number with floating point</param>
        /// <returns>byte view of source number</returns>
        public static string GetStringviewOfDouble(this double number)
        {
            long numberInBitsPerfomance = DoubleToInt64Bits(number);
            StringBuilder stringViewOfDouble = new StringBuilder(doubleLengthInBits);
            int[] bitarray = new int[doubleLengthInBits];
            long mask = 1;
            for (int i = doubleLengthInBits - 1; i >= 0; i--)
            {
                bitarray[i] = (int)(numberInBitsPerfomance & mask);
                numberInBitsPerfomance = numberInBitsPerfomance >> 1;
            }

            for (int i = 0; i < bitarray.Length; i++)
            {
                stringViewOfDouble.Append(bitarray[i].ToString());
            }

            return stringViewOfDouble.ToString();
        }

        private static unsafe long DoubleToInt64Bits(double value)
        {
            return *(long*)(&value);
        }
    }
}