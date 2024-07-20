using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionTests
{
    public class WordToDigitConverterTests
    {
        private IWordToDigitConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new WordToDigitConverter();
        }

        [Test]
        public void Convert_EnglishWords_ReturnsCorrectDigits()
        {
            string input = "ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE ZERO";
            string expected = "1 2 3 4 5 6 7 8 9 0";

            string result = _converter.Convert(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Convert_HindiWords_ReturnsCorrectDigits()
        {
            string input = "एक दो तीन चार पांच छह सात आठ नौ शून्य";
            string expected = "1 2 3 4 5 6 7 8 9 0";

            string result = _converter.Convert(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Convert_MixedWords_ReturnsCorrectDigits()
        {
            string input = "ONE दो THREE FOUR पांच";
            string expected = "1 2 3 4 5";

            string result = _converter.Convert(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Convert_NoWords_ReturnsSameInput()
        {
            string input = "1234567890";
            string expected = "1234567890";

            string result = _converter.Convert(input);

            Assert.AreEqual(expected, result);
        }
    }
}
