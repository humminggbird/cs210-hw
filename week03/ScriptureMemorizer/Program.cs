using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        List<Scripture> scriptures = LoadScriptures();

        Random random = new Random();

        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }

    static List<Scripture> LoadScriptures()
    {
        List<Scripture> scriptures = new List<Scripture>();

        string[] lines = File.ReadAllLines("scriptures.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string book = parts[0];
            int chapter = int.Parse(parts[1]);

            Reference reference;

            if (parts[2].Contains("-"))
            {
                string[] verses = parts[2].Split("-");

                int startVerse = int.Parse(verses[0]);
                int endVerse = int.Parse(verses[1]);

                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(parts[2]);

                reference = new Reference(book, chapter, verse);
            }

            string text = parts[3];

            Scripture scripture = new Scripture(reference, text);

            scriptures.Add(scripture);
        }

        return scriptures;
    }
}