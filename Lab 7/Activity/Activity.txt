using System;

namespace FirstFollowSet
{
    class Program
    {
        static int limit, x = 0;
        static string[,] production = new string[10, 10];
        static char[] array = new char[10];

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

            do
            {
                x = 0;
                Console.WriteLine("Enter production Value to Find Follow:");
                ch = Console.ReadKey().KeyChar;
                find_follow(ch);
                Console.WriteLine($"\nFollow Value of {ch}: {{");
                for (count = 0; count < x; count++)
                {
                    Console.Write(array[count]);
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

        static void find_follow(char ch)
        {
            int i = 0, j;

            if (production[0, 0].Equals(ch.ToString()))
            {
                array_manipulation('$');
            }

            for (i = 0; i < limit; i++)
            {
                for (j = 2; j < production[i, 0].Length; j++)
                {
                    if (production[i, j].Equals(ch.ToString()))
                    {
                        if (j + 1 < production[i, 0].Length)
                        {
                            find_first(production[i, j + 1][0]);
                        }
                        if (j + 1 == production[i, 0].Length && ch.Equals(production[i, 0][0]))
                        {
                            find_follow(production[i, 0][0]);
                        }
                    }
                }
            }
        }

        static void find_first(char ch)
        {
            int i = 0, k;

            int val = Convert.ToInt32(ch);
            if (!(val >= 97 && val <= 122))
            {
                array_manipulation(ch);
            }

            for (k = 0; k < limit; k++)
            {
                if (production[k, 0].Equals(ch.ToString()))
                {
                    if (production[k, 2].Equals("$"))
                    {
                        find_follow(production[i, 0][0]);
                    }
                    else if (Convert.ToInt32(production[k, 2][0]) >= 97 && Convert.ToInt32(production[k, 2][0]) <= 122)
                    {
                        array_manipulation(production[k, 2][0]);
                    }
                    else
                    {
                        find_first(production[k, 2][0]);
                    }
                }
            }
        }

        static void array_manipulation(char ch)
        {
            int count;
            for (count = 0; count <= x; count++)
            {
                if (array[count].Equals(ch))
                {
                    return;
                }
            }
            array[x++] = ch;
        }
    }
}
