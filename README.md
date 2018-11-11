Day4
----
1. Реализовать метод [TransformToWords](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms/TransformerToWords.cs) который принимает массив вещественных чисел и трансформирует его в массив строк таким образом, 
чтобы каждое вещественное число преобразовывалось в его "словестный формат" (LINQ-запросы не использовать!). 
Например, FilterDigit (-23.809, 0.295, 15.17) -> {"minus two three point eight zero nine", "zero point two nine five", "one five point one seven"}. 
Разработать модульные тесты ([NUnit](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms.Tests/TransformerToWordsTest.cs) или MS Unit Test) для тестирования метода.
2. Расширить функциональную возможность типа System.Double, реализовав возможность получения строкового представления вещественного числа в формате IEEE 754. Готовые классы-конверторы не использовать. Разработать модульные [тесты](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms.Tests/ExtenionDoubleTest.cs). [ExtensionDouble](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms/ExtensionDouble.cs)

    Примерные тест-кейсы:
    * [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
    * [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
    * [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
    * [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
    * [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
    * [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
    * [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
    * [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
    * [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
    * [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
    * [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")] и т.д.
3.	Разработать класс, позволяющий выполнять вычисления НОД по [алгоритму Евклида](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms/EuclideanAlgorithm.cs) для двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/ ). Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие [алгоритм Стейна (бинарный алгоритм Евклида)](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms/EuclideanAlgorithm.cs) для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ), а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать [модульные тесты](https://github.com/RomanGutovec/NET1.A.2018.Gutovec.4/blob/master/Algorithms.Tests/EuclideanAlgorithmTests.cs).
