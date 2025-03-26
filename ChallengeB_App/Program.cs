using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: ChallengeB_App <input_file> <output_file>");
            return;
        }

        string inputFile = args[0];
        string outputFile = args[1];

        try
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Error: Input file {inputFile} not found.");
                return;
            }

            string content = File.ReadAllText(inputFile);
            string[] objects = content.Split(',', StringSplitOptions.RemoveEmptyEntries);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (string obj in objects)
                {
                    string trimmedObj = obj.Trim();
                    string type = DetermineType(trimmedObj);
                    string line = $"Object: {trimmedObj}, Type: {type}";
                    Console.WriteLine(line);
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Processing complete. Output saved to {outputFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string DetermineType(string obj)
    {
        if (int.TryParse(obj, out _))
        {
            return "Integer";
        }
        else if (double.TryParse(obj, out _))
        {
            return "Real Number";
        }
        else if (obj.All(char.IsLetter))
        {
            return "Alphabetical String";
        }
        else if (obj.All(char.IsLetterOrDigit))
        {
            return "Alphanumeric String";
        }
        else
        {
            return "Unknown";
        }
    }
}
