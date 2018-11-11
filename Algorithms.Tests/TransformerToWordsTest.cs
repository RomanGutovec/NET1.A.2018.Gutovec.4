using System;
using NUnit.Framework;

namespace Algorithms.NUnit.Tests
{
    [TestFixture]
    public class TransformerToWordsTest
    {
        [TestCase(new double[] { -255.3, 0.5 }, ExpectedResult = "negative two five five dot three , zero dot five ")]
        [TestCase(new double[] { 0.345, -2.657 }, ExpectedResult = "zero dot three four five , negative two dot six five seven ")]
        [TestCase(new double[] { 10.392, 15.3 }, ExpectedResult = "one zero dot three nine two , one five dot three ")]
        [TestCase(new double[] { 0.392 }, ExpectedResult = "zero dot three nine two ")]
        public string TransformToWordsMethodTest(double[] numbers)
        => Algorithms.TransformerToWords.TransformToWords(numbers);
                
        [Test]
        public void TransformToWordsTest_arrayWithCapasity0_TrownArgumentNullException()
            => Assert.Throws<ArgumentException>(() => Algorithms.TransformerToWords.TransformToWords(new double[0]));
    }
}
