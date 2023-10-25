using System;
using System.Text.RegularExpressions;

namespace LogicalOperatorsRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Regular expression pattern for detecting logical operators
            string pattern = @"&&|\|\||!";

            Console.WriteLine("Enter a text to find logical operators:");
            string input = Console.ReadLine();

            // Use Regex to find and display logical operators in the input
            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count > 0)
            {
                Console.WriteLine("Logical operators found:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("No logical operators found in the input.");
            }
        }
    }
}
