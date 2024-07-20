using System.Collections.Generic;
using System.Text.RegularExpressions;

public class WordToDigitConverter : IWordToDigitConverter
{
    private readonly Dictionary<string, string> _englishToDigitMap = new Dictionary<string, string>
    {
        {"ONE", "1"}, {"TWO", "2"}, {"THREE", "3"},
        {"FOUR", "4"}, {"FIVE", "5"}, {"SIX", "6"},
        {"SEVEN", "7"}, {"EIGHT", "8"}, {"NINE", "9"},
        {"ZERO", "0"}
    };

    private readonly Dictionary<string, string> _hindiToDigitMap = new Dictionary<string, string>
    {
        {"एक", "1"}, {"दो", "2"}, {"तीन", "3"},
        {"चार", "4"}, {"पांच", "5"}, {"छह", "6"},
        {"सात", "7"}, {"आठ", "8"}, {"नौ", "9"},
        {"शून्य", "0"} // Note: Hindi "शूए" is placeholder, replace with correct translation
    };

    public string Convert(string input)
    {
        foreach (var kvp in _englishToDigitMap)
        {
            input = Regex.Replace(input, kvp.Key, kvp.Value, RegexOptions.IgnoreCase);
        }

        foreach (var kvp in _hindiToDigitMap)
        {
            input = Regex.Replace(input, kvp.Key, kvp.Value, RegexOptions.IgnoreCase);
        }

        return input;
    }
}
