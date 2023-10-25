using System;
using System.Collections.Generic;

namespace FirstFollowSet
{
    class Program
    {
        static int limit, x = 0;
        static string[,] production = new string[10, 10];
        static Dictionary<char, List<char>> firstSets = new Dictionary<char, List<char>>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    production[i, j] = "-";
                }
            }

            int count;
            char option, ch;
            Console.WriteLine("Enter Total Number of Productions:");
            limit = Convert.ToInt32(Console.ReadLine());

            for (count = 0; count < limit; count++)
            {
                Console.WriteLine($"Value of Production Number {count + 1}:");
                string temp = Console.ReadLine();
                for (int i = 0; i < temp.Length; i++)
                {
                    production[count, i] = temp[i].ToString();
                }
            }

            // Initialize FIRST sets for terminals
            foreach (char terminal in GetTerminals())
            {
                firstSets[terminal] = new List<char> { terminal };
            }

            do
            {
                x = 0;
                Console.WriteLine("Enter production Value to Find FIRST:");
                ch = Console.ReadKey().KeyChar;
                CalculateFirst(ch);
                Console.WriteLine($"\nFIRST Value of {ch}: {{");
                foreach (char symbol in firstSets[ch])
                {
                    Console.Write(symbol + " ");
                }
                Console.Write("}\n");
                Console.Write("To Continue, Press Y: ");
                option = Console.ReadKey().KeyChar;
            } while (option == 'y' || option == 'Y');

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(production[i, j]);
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }

        static IEnumerable<char> GetTerminals()
        {
            List<char> terminals = new List<char>();
            for (int i = 0; i < limit; i++)
            {
                string rhs = production[i, 2];
                foreach (char symbol in rhs)
                {
                    if (!char.IsUpper(symbol) && symbol != '$' && !terminals.Contains(symbol))
                    {
                        terminals.Add(symbol);
                    }
                }
            }
            return terminals;
        }

        static void CalculateFirst(char ch)
        {
            if (!char.IsUpper(ch))
            {
                return; // Terminal symbol
            }

            if (!firstSets.ContainsKey(ch))
            {
                firstSets[ch] = new List<char>();
            }

            for (int i = 0; i < limit; i++)
            {
                if (production[i, 0][0] == ch)
                {
                    string rhs = production[i, 2];
                    if (rhs.Length == 0 || (rhs.Length == 1 && rhs[0] == '$'))
                    {
                        firstSets[ch].Add('$');
                    }
                    else
                    {
                        char symbol = rhs[0];
                        if (char.IsUpper(symbol))
                        {
                            CalculateFirst(symbol);
                            foreach (char firstSymbol in firstSets[symbol])
                            {
                                firstSets[ch].Add(firstSymbol);
                            }
                        }
                        else
                        {
                            firstSets[ch].Add(symbol);
                        }
                    }
                }
            }
        }
    }
}