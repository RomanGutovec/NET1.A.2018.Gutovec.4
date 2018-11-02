using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    public delegate StringBuilder TransformerOneDouble(double oneNumber);

    /// <summary>
    /// Transforms numbers with floating point 
    /// to string with string view of each digit or sign
    /// </summary>
    public static class TransformerToWords
    {
        private static readonly string[] digitsInWords =
            {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "dot",
            "negative"
            };

        private static readonly char[] digitsLikeChars =
            {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '.',
            '-',
            };

        /// <summary>
        /// Transform each digit of numbers with floating point
        /// into string view
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source array have null value</exception>
        /// <exception cref="ArgumentException">thrown when source array is empty</exception>
        /// <param name="arrayOfDoubles">array of numbers with floating point</param>
        /// <returns>each digit of source number as string</returns>
        public static string TransformToWords(double[] arrayOfDoubles)
        {
            if (arrayOfDoubles == null)
            {
                throw new ArgumentNullException($"Array {nameof(arrayOfDoubles)} have null value");
            }

            if (arrayOfDoubles.Length == 0)
            {
                throw new ArgumentException($"Array {nameof(arrayOfDoubles)} is empty");
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < arrayOfDoubles.Length; i++)
            {
                resultString.Append(TransformerOneDoubleToWord(arrayOfDoubles[i]));
                if (i != arrayOfDoubles.Length - 1)
                {
                    resultString.Append(", ");
                }
            }

            return resultString.ToString();
        }

        public static string TransformToWords(double[] arrayOfDoubles, TransformerOneDouble transformOneDouble)
        {
            if (arrayOfDoubles == null)
            {
                throw new ArgumentNullException($"Array {nameof(arrayOfDoubles)} have null value");
            }

            if (arrayOfDoubles.Length == 0)
            {
                throw new ArgumentException($"Array {nameof(arrayOfDoubles)} is empty");
            }

            StringBuilder resultString = new StringBuilder();
            TransformerOneDouble transformation = TransformerOneDoubleToWord;
            for (int i = 0; i < arrayOfDoubles.Length; i++)
            {
                resultString.Append(transformation(arrayOfDoubles[i]));
            }

            return resultString.ToString();
        }

        public static string TransformToIEEEFormat(double[] arrayOfDoubles)
        {
            if (arrayOfDoubles == null)
            {
                throw new ArgumentNullException($"Array {nameof(arrayOfDoubles)} have null value");
            }

            if (arrayOfDoubles.Length == 0)
            {
                throw new ArgumentException($"Array {nameof(arrayOfDoubles)} is empty");
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < arrayOfDoubles.Length; i++)
            {
                resultString.Append(TransformerOneDoubleToWord(arrayOfDoubles[i]));
                if (i != arrayOfDoubles.Length - 1)
                {
                    resultString.Append(", ");
                }
            }

            return resultString.ToString();
        }

        private static StringBuilder TransformerOneDoubleToWord(double number)
        {
            string representation = number.ToString();
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < representation.Length; i++)
            {
                resultString.Append(digitsInWords[Array.IndexOf(digitsLikeChars, representation[i])]);
                resultString.Append(' ');
            }

            return resultString;
        }
    }
}
