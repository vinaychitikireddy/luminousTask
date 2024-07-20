using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectionTests
{
    public class PhoneNumberDetectorTests
    {
        private IPhoneNumberDetector _detector;

        [SetUp]
        public void Setup()
        {
            IWordToDigitConverter converter = new WordToDigitConverter();
            _detector = new PhoneNumberDetector(converter);
        }

        [Test]
        public void DetectPhoneNumbers_Valid10DigitNumbers_ReturnsDetectedNumbers()
        {
            string input = "Call me at 123-456-7890 or 9876543210.";
            List<string> expected = new List<string> { "123-456-7890", "9876543210" };

            List<string> result = new List<string>(); 
                _detector.ContainsPhoneNumber(input,out result);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void DetectPhoneNumbers_ValidCountryCodeNumbers_ReturnsDetectedNumbers()
        {
            string input = "My numbers are +1-123-456-7890 and +91 9876543210.";
            List<string> expected = new List<string> { "+1-123-456-7890", "+91 9876543210" };

            List<string> result = new List<string>();
                _detector.ContainsPhoneNumber(input, out result);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void DetectPhoneNumbers_ValidParenthesesNumbers_ReturnsDetectedNumbers()
        {
            string input = "Office number is (123) 456-7890 and home number is (91) 1234567890.";
            List<string> expected = new List<string> { "(123) 456-7890", "(91) 1234567890" };

            List<string> result = new List<string>();
                _detector.ContainsPhoneNumber(input,out result);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void DetectPhoneNumbers_MixedFormats_ReturnsDetectedNumbers()
        {
            string input = "Reach me at ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE ZERO or 123-456-7890.";
            List<string> expected = new List<string> { "123-456-7890", "1234567890" };

            List<string> result = new List<string>();
            _detector.ContainsPhoneNumber(input, out result);
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void DetectPhoneNumbers_NoPhoneNumbers_ReturnsEmptyList()
        {
            string input = "No phone numbers here!";
            List<string> expected = new List<string>();

            List<string> result = new List<string>();
            _detector.ContainsPhoneNumber(input, out result);
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
