using System;
using System.IO;

public class SimpleJavaParser
{
    private readonly StreamReader streamReader;

    public SimpleJavaParser(string input)
    {
        streamReader = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(input)));
    }

    public void Parse()
    {
        ParseBlock();
    }

    private void ParseBlock()
    {
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
            string[] tokens = line.Split(new char[] { ' ', '(', ')', ';', '{', '}', '<', '>', '=', '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 0)
            {
                continue; // Skip empty lines
            }

            if (tokens[0] == "int")
            {
                if (tokens.Length >= 2)
                {
                    ParseVariableDeclaration(tokens[1]);
                }
                else
                {
                    Console.WriteLine("Error: Incomplete variable declaration.");
                }
            }
            else if (tokens[0] == "if")
            {
                ParseIfStatement(line);
            }
            else if (tokens[0] == "while")
            {
                ParseWhileLoop(line);
            }
            else if (tokens.Length >= 3 && tokens[1] == "=")
            {
                ParseAssignment(tokens[0], tokens[2]);
            }
            else
            {
                Console.WriteLine("Error: Unrecognized statement.");
            }
        }
    }

    private void ParseVariableDeclaration(string identifier)
    {
        Console.WriteLine($"Variable declaration: int {identifier}");
    }

    private void ParseAssignment(string identifier, string value)
    {
        Console.WriteLine($"Assignment: {identifier} = {value}");
    }

    private void ParseIfStatement(string line)
    {
        Console.WriteLine($"If statement: {line}");
    }

    private void ParseWhileLoop(string line)
    {
        Console.WriteLine($"While loop: {line}");
    }

    public static void Main(string[] args)
    {
        string input =
            "int x;\n" +
            "x = 10;\n" +
            "if (x > 5)\n" +
            "{\n" +
            "    x = x - 1;\n" +
            "}\n" +
            "while (x > 0)\n" +
            "{\n" +
            "    x = x - 1;\n" +
            "}";

        SimpleJavaParser parser = new SimpleJavaParser(input);
        parser.Parse();
    }
}
