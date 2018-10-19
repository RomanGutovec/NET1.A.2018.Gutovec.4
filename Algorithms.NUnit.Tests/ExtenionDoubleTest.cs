﻿using System;
using NUnit.Framework;

namespace Algorithms.NUnit.Tests
{
    [TestFixture]
    public class ExtensionDoubleTests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(956.394, ExpectedResult = "0100 0000 1000 1101 1110 0011 0010 0110 1110 1001 0111 1000 1101 0100 1111 1101")]
        [TestCase(-1.1, ExpectedResult = "0111 1111 1111 0001 1001 1001 1001 1001 1001 1001 1001 1001 1001 1001 1001 1001")]
        public string GetStringviewOfDoubleMethodTest(double number)
        => number.GetStringviewOfDouble();
    }
}