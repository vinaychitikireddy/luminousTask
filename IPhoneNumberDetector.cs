public interface IPhoneNumberDetector
{
    bool ContainsPhoneNumber(string input, out List<string> detectedNumbers);
}