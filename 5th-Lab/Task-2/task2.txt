using System;
using System.Collections.Generic;

class SymbolTable<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>>[] buckets;
    private int capacity;
    private int size;

    public SymbolTable(int capacity)
    {
        this.capacity = capacity;
        this.buckets = new List<KeyValuePair<TKey, TValue>>[capacity];
        this.size = 0;
    }

    private int Hash(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % capacity;
    }

    public void Add(TKey key, TValue value)
    {
        int index = Hash(key);

        if (buckets[index] == null)
        {
            buckets[index] = new List<KeyValuePair<TKey, TValue>>();
        }

        foreach (var pair in buckets[index])
        {
            if (pair.Key.Equals(key))
            {
                throw new InvalidOperationException("Key already exists in the symbol table.");
            }
        }

        buckets[index].Add(new KeyValuePair<TKey, TValue>(key, value));
        size++;
    }

    public TValue Get(TKey key)
    {
        int index = Hash(key);

        if (buckets[index] != null)
        {
            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }

        throw new KeyNotFoundException($"Key '{key}' not found in the symbol table.");
    }

    public int Size()
    {
        return size;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SymbolTable<string, int> symbolTable = new SymbolTable<string, int>(10);

        symbolTable.Add("Ali", 20);
        symbolTable.Add("Alyaan", 21);
        symbolTable.Add("Naqeeb", 20);
        Console.WriteLine("This is Using HashTables:: ");
        Console.WriteLine("Size of symbol table: " + symbolTable.Size());
        Console.WriteLine("Age of Ali: " + symbolTable.Get("Ali"));
        Console.WriteLine("Age of Alyaan: " + symbolTable.Get("Alyaan"));
        Console.WriteLine("Age of Naaqeeb: " + symbolTable.Get("Naqeeb"));

        try
        {
            Console.WriteLine("Value of w: " + symbolTable.Get("w"));
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
