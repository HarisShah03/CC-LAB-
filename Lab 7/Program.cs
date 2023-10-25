using System;

namespace CFGExample
{
    class Program
    {
        static string[] nonTerminals = { "S", "A", "B", "C" };
        static string[] terminals = { "a", "b", "c", "d" };
        static string[,] productions = new string[4, 2];

        static void Main(string[] args)
        {
            // Define the grammar productions
            productions[0, 0] = "S";
            productions[0, 1] = "AB";
            productions[1, 0] = "A";
            productions[1, 1] = "aA|ε";
            productions[2, 0] = "B";
            productions[2, 1] = "bB|c";
            productions[3, 0] = "C";
            productions[3, 1] = "cd";

            Console.WriteLine("Grammar Productions:");
            for (int i = 0; i < nonTerminals.Length; i++)
            {
                Console.Write(nonTerminals[i] + " -> ");
                string[] productionOptions = productions[i, 1].Split('|');
                for (int j = 0; j < productionOptions.Length; j++)
                {
                    Console.Write(productionOptions[j] + " ");
                }
                Console.WriteLine();
            }

            // Example: Find the production for non-terminal A
            string productionA = FindProduction("A");
            Console.WriteLine("Production for A: " + productionA);

            // Example: Check if 'c' is a terminal
            bool isCTerminal = IsTerminal("c");
            Console.WriteLine("'c' is a terminal: " + isCTerminal);

            Console.ReadKey();
        }

        static string FindProduction(string nonTerminal)
        {
            for (int i = 0; i < nonTerminals.Length; i++)
            {
                if (nonTerminals[i] == nonTerminal)
                {
                    return productions[i, 1];
                }
            }
            return null;
        }

        static bool IsTerminal(string symbol)
        {
            for (int i = 0; i < terminals.Length; i++)
            {
                if (terminals[i] == symbol)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

