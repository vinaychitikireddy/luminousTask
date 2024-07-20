using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

public class PhoneNumberDetector : IPhoneNumberDetector
{
    private readonly IWordToDigitConverter _wordToDigitConverter;

    public PhoneNumberDetector(IWordToDigitConverter wordToDigitConverter)
    {
        _wordToDigitConverter = wordToDigitConverter;
    }

    public bool ContainsPhoneNumber(string input, out List<string> detectedNumbers)
    {
        detectedNumbers = new List<string>();
        string convertedInput = input;
        string pureTenDigitNumber = @"\(\d{1,3}\)\s*\d{7,10}";
        string withCountryCode = @"\+\d{1,3}[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,4}\b|(\(\d{2}\))\s(\d{10})";  // Numbers with country codes
        string withSeparators = @"\b\d{3}[-.\s]?\d{3}[-.\s]?\d{4}\b"; // Numbers with separators
        string withParenthesesCodes = @"\(\d{1,3}\)[-\s]?\d{3}[-.\s]?\d{4}\b"; // Numbers with parentheses for area codes

        string[] patterns = {

            @"\(\d{1,3}\)\s*\d{7,10}",
            @"\+\d{1,3}[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,4}\b",  // Numbers with country codes
            @"\+\d{1,3}-\d{3}-\d{3}-\d{4}",
            @"\b\d{3}[-.\s]?\d{3}[-.\s]?\d{4}\b", // Numbers with separators
            @"\(\d{1,3}\)[-\s]?\d{3}[-.\s]?\d{4}\b" // Numbers with parentheses for area codes
       };
        List<string> listPhonenumbers = new List<string>();

        convertedInput = ParseUsingRegex(convertedInput, withCountryCode, ref listPhonenumbers);
        convertedInput = ParseUsingRegex(convertedInput, withSeparators, ref listPhonenumbers);
        convertedInput = ParseUsingRegex(convertedInput, withParenthesesCodes, ref listPhonenumbers);
        convertedInput = ParseUsingRegex(convertedInput, withParenthesesCodes, ref listPhonenumbers);

        foreach (var pattern in patterns)
        {
            convertedInput = _wordToDigitConverter.Convert(convertedInput);
            string spaceDetectionpattern = @"(?<=\d)\s+(?=\d)";
            Regex regex = new Regex(spaceDetectionpattern);
            convertedInput = regex.Replace(convertedInput, "");
            MatchCollection wordMatches = Regex.Matches(convertedInput, pattern);

            foreach (Match match in wordMatches)
            {
                convertedInput = convertedInput.Replace("\r\n", "").Replace(match.Value, "");
            }
             
                foreach (Match match in wordMatches)
                {
                    if (!listPhonenumbers.Contains(match.Value))
                    {
                        listPhonenumbers.Add(match.Value);
                    }
                }
            
        };

        detectedNumbers.AddRange(listPhonenumbers);
        return detectedNumbers.Count > 0;
    }

    private string ParseUsingRegex(string inputString, string regex, ref List<string> listPhoneNumbers)
    {

        MatchCollection matches = Regex.Matches(inputString, regex);
        foreach (Match match in matches)
        {
            inputString = inputString.Replace("\r\n", "").Replace(match.Value, "");
        }
         
            foreach (Match match in matches)
            {
                if (!listPhoneNumbers.Contains(match.Value))
                {
                    listPhoneNumbers.Add(match.Value);
                }
            }
         
        return inputString;
    }


}
