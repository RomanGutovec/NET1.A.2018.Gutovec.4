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
            return GCDEuclid(firstNumber, GCDRecursion(secondNumber, thirdNumber));
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
        public static int GCDEuclid(int firstNumber, params int[] nextNumbers)
        {
            if (nextNumbers.Length < 1)
            {
                throw new ArgumentException("Amount of parametres must be greater then two");
            }

            if (nextNumbers == null)
            {
                throw new NullReferenceException($"Argument {nameof(nextNumbers)} have null value");
            }

            int resultNumber = Math.Abs(GCDEuclid(firstNumber, nextNumbers[0]));
            for (int i = 1; i < nextNumbers.Length; i++)
            {
                resultNumber = Math.Abs(GCDEuclid(resultNumber, nextNumbers[i]));
            }

            return resultNumber;
        }

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
            int resultNumber = GCDEuclid(firstNumber, GCDEuclid(secondNumber, thirdNumber));
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
        public static int GCDEuclid(int firstNumber, out long elapsedMillisecond, params int[] nextNumbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = Math.Abs(GCDEuclid(firstNumber, nextNumbers[0]));
            for (int i = 1; i < nextNumbers.Length; i++)
            {
                resultNumber = Math.Abs(GCDEuclid(resultNumber, nextNumbers[i]));
            }

            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

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
        {
            return Math.Abs(GCDBinary(GCDBinary(firstNumber, secondNumber), thirdNumber));
        }

        /// <summary>
        /// Find greater common divisor of numbers
        /// by Binary method
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when was input only one number</exception>
        /// <exception cref="NullReferenceException">Thrown when was input null value</exception>
        /// <param name="firstNumber">first source number</param>
        /// <param name="secondNumber">second source number</param>
        /// <returns>value of greater common divisor</returns>
        public static int GCDBinary(int firstNumber, params int[] nextNumbers)
        {
            if (nextNumbers.Length < 1)
            {
                throw new ArgumentException("Amount of parametres must be greater then two");
            }

            if (nextNumbers == null)
            {
                throw new NullReferenceException($"Argument {nameof(nextNumbers)} have null value");
            }

            int resultNumber = Math.Abs(GCDBinary(firstNumber, nextNumbers[0]));
            for (int i = 1; i < nextNumbers.Length; i++)
            {
                resultNumber = Math.Abs(GCDBinary(resultNumber, nextNumbers[i]));
            }

            return resultNumber;
        }

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
            int resultNumber = GCDBinary(firstNumber, GCDBinary(secondNumber, thirdNumber));
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
        public static int GCDBinary(int firstNumber, out long elapsedMillisecond, params int[] nextNumbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = Math.Abs(GCDBinary(firstNumber, nextNumbers[0]));
            for (int i = 1; i < nextNumbers.Length; i++)
            {
                resultNumber = Math.Abs(GCDBinary(resultNumber, nextNumbers[i]));
            }

            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

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
            return GCDRecursion(firstNumber, GCDRecursion(secondNumber, thirdNumber));
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
        public static int GCDRecursion(int firstNumber, params int[] nextNumbers)
        {
            if (nextNumbers.Length < 1)
            {
                throw new ArgumentException("Amount of parametres must be greater then two");
            }

            if (nextNumbers == null)
            {
                throw new NullReferenceException($"Argument {nameof(nextNumbers)} have null value");
            }

            int resultNumber = Math.Abs(GCDRecursion(firstNumber, nextNumbers[0]));
            for (int i = 1; i < nextNumbers.Length; i++)
            {
                resultNumber = Math.Abs(GCDRecursion(resultNumber, nextNumbers[i]));
            }

            return resultNumber;
        }

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
            int resultNumber = GCDRecursion(firstNumber, GCDRecursion(secondNumber, thirdNumber));
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
        public static int GCDRecursion(int firstNumber, out long elapsedMillisecond, params int[] nextNumbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int resultNumber = Math.Abs(GCDRecursion(firstNumber, nextNumbers[0]));
            for (int i = 1; i < nextNumbers.Length; i++)
            {
                resultNumber = Math.Abs(GCDRecursion(resultNumber, nextNumbers[i]));
            }

            watch.Stop();
            elapsedMillisecond = watch.ElapsedMilliseconds;
            return resultNumber;
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
    }
}