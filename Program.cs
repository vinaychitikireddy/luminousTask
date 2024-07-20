using System;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IWordToDigitConverter, WordToDigitConverter>()
            .AddSingleton<IPhoneNumberDetector, PhoneNumberDetector>()
            .BuildServiceProvider();

        var phoneNumberDetector = serviceProvider.GetService<IPhoneNumberDetector>();

        string fileContent = string.Empty;
        Console.WriteLine("Enter the file Location");
        try
        {
            string inputFilename = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputFilename))
            {
                //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //string fileName = "notepad.txt";
                //string filePath = Path.Combine(documentsPath, fileName);
                fileContent = File.ReadAllText(inputFilename);
                Console.WriteLine(fileContent);
            }
            
             
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        string input = fileContent;
        List<string> detectedNumbers = new List<string>();
        //var detectedNumbers = phoneNumberDetector.ContainsPhoneNumber(input, out strings);

        if (phoneNumberDetector.ContainsPhoneNumber(input, out detectedNumbers))
        {
            Console.WriteLine("\nDetected Phone Numbers:");
            foreach (var number in detectedNumbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("\nNo phone numbers detected.");
        }
         
    }
}
