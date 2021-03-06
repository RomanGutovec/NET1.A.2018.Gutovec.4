﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
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
        public static string TransformToWords<TSource>(TSource[] arrayOfDoubles)
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
                string representation = arrayOfDoubles[i].ToString();
                TransformerOneDoubleToWord(representation, resultString);
                if (i != arrayOfDoubles.Length - 1)
                {
                    resultString.Append(", ");
                }
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
                string representation = arrayOfDoubles[i].GetStringviewOfDouble();
                TransformerOneDoubleToWord(representation, resultString);
                if (i != arrayOfDoubles.Length - 1)
                {
                    resultString.Append(", ");
                }
            }

            return resultString.ToString();
        }

        public static void TransformerOneDoubleToWord(string representation, StringBuilder resultString)
        {
            for (int i = 0; i < representation.Length; i++)
            {
                resultString.Append(digitsInWords[Array.IndexOf(digitsLikeChars, representation[i])]);
                resultString.Append(' ');
            }
        }
    }
}
