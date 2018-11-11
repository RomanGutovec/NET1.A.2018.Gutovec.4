using System;
using NUnit.Framework;

namespace Algorithms.NUnit.Tests
{
    [TestFixture]
    public class EuclideanAlgorithmTests
    {
        [TestCase(4, 8, ExpectedResult = 4)]
        [TestCase(1, -3, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(-17, 34, ExpectedResult = 17)]
        [TestCase(792, -1188, ExpectedResult = 396)]
        [TestCase(14, -28, 7, ExpectedResult = 7)]
        [TestCase(-3, 27, -54, ExpectedResult = 3)]
        [TestCase(-6, 12, -24, 12, ExpectedResult = 6)]
        [TestCase(7, -14, 49, 98, ExpectedResult = 7)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-18, 0, ExpectedResult = 18)]
        public int GCDEuclidMethodTest(params int[] numberNext)
        => Algorithms.EuclideanAlgorithm.GCDEuclid(numberNext);

        [TestCase(0)]
        [TestCase(-5)]
        public void GCDEuclidMethodTest_AmountLessThen2_ArgumentException(int firstNumber, params int[] numberNext)
                => Assert.Throws<ArgumentException>(() => Algorithms.EuclideanAlgorithm.GCDEuclid(numberNext));

        [Test]
        public void GCDEuclidMethodTest_Null_ThrownNullReferenceException()
        => Assert.Throws<NullReferenceException>(() => Algorithms.EuclideanAlgorithm.GCDEuclid(null));

        [TestCase(4, 8, ExpectedResult = 4)]
        [TestCase(1, 8, ExpectedResult = 1)]
        [TestCase(-1, 1, ExpectedResult = 1)]
        [TestCase(13, -26, ExpectedResult = 13)]
        [TestCase(792, -1188, ExpectedResult = 396)]
        [TestCase(11, 22, -121, ExpectedResult = 11)]
        [TestCase(9, -63, 126, ExpectedResult = 9)]
        [TestCase(-6, 12, -24, 12, ExpectedResult = 6)]
        [TestCase(64, -8, 24, 8, ExpectedResult = 8)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(11, 0, ExpectedResult = 11)]
        public int GCDBinaryMethodTest(params int[] numberNext)
        => Algorithms.EuclideanAlgorithm.GCDBinary(numberNext);

        [TestCase(15)]
        [TestCase(-8)]
        public void GCDBinaryMethodTest_AmountLessThen2_ArgumentException(params int[] numberNext)
        => Assert.Throws<ArgumentException>(() => Algorithms.EuclideanAlgorithm.GCDRecursion(numberNext));

        [Test]
        public void GCDBinaryMethodTest_Null_ThrownNullReferenceException()
        => Assert.Throws<NullReferenceException>(() => Algorithms.EuclideanAlgorithm.GCDRecursion(null));
        [TestCase(6, 3, ExpectedResult = 3)]
        [TestCase(5, 1, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(-18, 36, ExpectedResult = 18)]
        [TestCase(792, -1188, ExpectedResult = 396)]
        [TestCase(14, -28, 7, ExpectedResult = 7)]
        [TestCase(-2, 34, 128, ExpectedResult = 2)]
        [TestCase(-6, 12, -24, 12, ExpectedResult = 6)]
        [TestCase(5, -15, 50, 125, ExpectedResult = 5)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, -35, ExpectedResult = 35)]
        public int GCDRecursionMethodTest(params int[] numberNext)
             => Algorithms.EuclideanAlgorithm.GCDRecursion(numberNext);

        [TestCase(0)]
        [TestCase(-5)]
        public void GCDRecursionMethodTest_AmountLessThen2_ArgumentException(params int[] numberNext)
                => Assert.Throws<ArgumentException>(() => Algorithms.EuclideanAlgorithm.GCDRecursion(numberNext));

        [Test]
        public void GCDRecursionMethodTest_Null_ThrownNullReferenceException()
        => Assert.Throws<NullReferenceException>(() => Algorithms.EuclideanAlgorithm.GCDRecursion(null));
    }
}
