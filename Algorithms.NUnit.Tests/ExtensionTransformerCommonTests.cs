using System;
using Algorithms.NUnit.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.NUnit.Tests
{
    [TestFixture]
    public class ExtensionTransformerCommonTests
    {
        [Test]
        public void FilterTests_InputStrings_ReturnsEvenNumbers()
        {
            string[] source = new string[] { "12345", "12", "12345", "34567" };
            string[] expected = { "12345", "12345", "34567" };
            CollectionAssert.AreEqual(expected, source.Filter(new PredicatesForStrings().IsMatchLengthFive));
        }

        [TestCase(new int[] { -255, 5, 6, 4 }, ExpectedResult = new int[] { 6, 4 })]
        [TestCase(new int[] { -4, -2, -6, -8, 0 }, ExpectedResult = new int[] { -4, -2, -6, -8, 0 })]
        [TestCase(new int[] { -13, 8, 6, 4 }, ExpectedResult = new int[] { 8, 6, 4 })]
        public int[] FilterTests_InputArrayNumbers_ReturnsEvenNumbers(int[] numbers)
        => numbers.Filter(new PredicatesForDigits().IsEven);

        [TestCase(new int[] { -255, 11, 17, 4 }, ExpectedResult = new int[] { 11, 17 })]
        [TestCase(new int[] { -3, 7, -2, -6, -8, 0 }, ExpectedResult = new int[] { -3, 7 })]
        [TestCase(new int[] { -13, 8, 6, 4 }, ExpectedResult = new int[] { -13 })]
        public int[] FilterTests_InputArrayNumbers_ReturnSimpleNumbers(int[] numbers)
        => numbers.Filter(new PredicatesForDigits().IsSimple);

        [TestCase(new int[] { -255, 11, 17, 4 }, ExpectedResult = new int[] { 11, 17 })]
        [TestCase(new int[] { -3, 7, -2, -6, -8, 0, 1 }, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { -13, 8, 6, 4 }, ExpectedResult = new int[] { -13 })]
        public int[] FilterTests_InputArrayNumbers_ReturnNumbersWhichConatains1(int[] numbers)
        => numbers.Filter(new PredicatesForDigits().IsContainsOne);
    }
}
