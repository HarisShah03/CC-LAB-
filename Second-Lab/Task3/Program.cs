using System;
using System.Text.RegularExpressions;

namespace RelationalOperatorsRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Regular expression pattern for detecting relational operators
            string pattern = @"[<>]=?|==|!=";

            Console.WriteLine("Enter a text to find relational operators:");
            string input = Console.ReadLine();

            // Use Regex to find and display relational operators in the input
            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count > 0)
            {
                Console.WriteLine("Relational operators found:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("No relational operators found in the input.");
            }
        }
    }
}
