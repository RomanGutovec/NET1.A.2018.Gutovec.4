using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Find greater common divisor of numbers
    /// by Euclidean algorithm 
    /// </summary>
    public class EuclideanAlgorithm
    {
        #region Gcd classic Euclid's algorithm
        /// <summary>
        /// Find greater common divisor of numbers
        /// by classic Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDEuclid(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return Math.Abs(secondNumber);
            }

            if (secondNumber == 0)
            {
                return Math.Abs(firstNumber);
            }

            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

            if (firstNumber == 1 || secondNumber == 1)
            {
                return 1;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber < secondNumber)
            {
                Swap(ref firstNumber, ref secondNumber);
            }

            int resultNumber = secondNumber;
            int remaind = firstNumber % secondNumber;
            while (remaind != 0)
            {
                int temp = remaind;
                remaind = resultNumber % remaind;
                resultNumber = temp;
            }

            return resultNumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by classic Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDEuclid(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GCD3Elements(GCDEuclid, firstNumber, secondNumber, thirdNumber);
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by classic Euclidean algorithm
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDEuclid(params int[] numbers)
         => GCDManyElements(GCDEuclid, numbers);

        /// <summary>
        /// Find greater common divisor of numbers
        /// by classic Euclidean algorithm and calculate time of executing the method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDEuclid(int firstNumber, int secondNumber, out long elapsedMillisecond)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultnumber = Math.Abs(GCDEuclid(firstNumber, secondNumber));
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultnumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by classic Euclidean algorithm and calculate time of executing the method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDEuclid(int firstNumber, int secondNumber, int thirdNumber, out long elapsedMillisecond)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCD3Elements(GCDEuclid, firstNumber, secondNumber, thirdNumber);
            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by classic Euclidean algorithm and calculate time of executing the method
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDEuclid(out long elapsedMillisecond, params int[] nextNumbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCDManyElements(GCDEuclid, nextNumbers);
            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }
        #endregion

        #region GCD Binary algorithm
        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return Math.Abs(secondNumber);
            }

            if (secondNumber == 0)
            {
                return Math.Abs(firstNumber);
            }

            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

            if (firstNumber == secondNumber)
            {
                return Math.Abs(firstNumber);
            }

            if (firstNumber == 0)
            {
                return Math.Abs(secondNumber);
            }

            if (secondNumber == 0)
            {
                return Math.Abs(firstNumber);
            }

            if ((~firstNumber & 1) != 0)
            {
                if ((secondNumber & 1) != 0)
                {
                    return Math.Abs(GCDBinary(firstNumber >> 1, secondNumber));
                }
                else
                {
                    return Math.Abs(GCDBinary(firstNumber >> 1, secondNumber >> 1) << 1);
                }
            }

            if ((~secondNumber & 1) != 0)
            {
                return Math.Abs(GCDBinary(firstNumber, secondNumber >> 1));
            }

            if (firstNumber > secondNumber)
            {
                return Math.Abs(GCDBinary((firstNumber - secondNumber) >> 1, secondNumber));
            }

            return Math.Abs(GCDBinary((secondNumber - firstNumber) >> 1, firstNumber));
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(int firstNumber, int secondNumber, int thirdNumber)
            => Math.Abs(GCD3Elements(GCDBinary, firstNumber, secondNumber, thirdNumber));

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(params int[] numbers)
        => GCDManyElements(GCDBinary, numbers);

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method and calculate time of executing the method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(int firstNumber, int secondNumber, out long elapsedMillisecond)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCDBinary(firstNumber, secondNumber);
            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method and calculate time of executing the method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(int firstNumber, int secondNumber, int thirdNumber, out long elapsedMillisecond)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCD3Elements(GCDBinary, firstNumber, secondNumber, thirdNumber);
            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method and calculate time of executing the method
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(out long elapsedMillisecond, params int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCDManyElements(GCDBinary, numbers);
            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }
        #endregion

        #region simple finder GCD
        /// <summary>
        /// Find greater common divisor of numbers
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDRecursion(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                return Math.Abs(firstNumber);
            }

            return Math.Abs(GCDRecursion(secondNumber, firstNumber % secondNumber));
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDRecursion(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GCD3Elements(GCDRecursion, firstNumber, secondNumber, thirdNumber);
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Recursion method
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDRecursion(params int[] numbers)
         => GCDManyElements(GCDRecursion, numbers);

        /// <summary>
        /// Find greater common divisor of numbers
        /// and calculate time of executing the method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDRecursion(int firstNumber, int secondNumber, out long elapsedMillisecond)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultnumber = Math.Abs(GCDRecursion(firstNumber, secondNumber));
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultnumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// and calculate time of executing the method
        /// </summary>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDRecursion(int firstNumber, int secondNumber, int thirdNumber, out long elapsedMillisecond)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCD3Elements(GCDRecursion, firstNumber, secondNumber, thirdNumber);
            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// calculate time of executing the method
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDRecursion(out long elapsedMillisecond, params int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = GCDManyElements(GCDRecursion, numbers);

            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }
        #endregion

        #region methods with delegates are common for all
        private static int GCD3Elements(Func<int, int, int> gcdAlgorithmKind, int firstNumber, int secondNumber, int thirdNumber)
           => gcdAlgorithmKind(gcdAlgorithmKind(firstNumber, secondNumber), thirdNumber);

        private static int GCDManyElements(Func<int, int, int> gcdAlgorithmKind, params int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                throw new ArgumentException("Must be two or more arguments");
            }

            if (numbers == null)
            {
                throw new NullReferenceException($"Argument {nameof(numbers)} have null value");
            }

            int result = gcdAlgorithmKind(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length && result != 1; i++)
            {
                result = gcdAlgorithmKind(result, numbers[i]);
            }

            return result;
        }
        #endregion

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
    }
}