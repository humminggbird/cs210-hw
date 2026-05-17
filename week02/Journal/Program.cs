using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);

                Console.Write("> ");

                string response = Console.ReadLine();

                Console.Write("What is your mood today? ");

                string mood = Console.ReadLine();

                Entry newEntry = new Entry();

                newEntry._date = DateTime.Now.ToShortDateString();

                newEntry._promptText = prompt;

                newEntry._entryText = response;

                newEntry._mood = mood;

                journal.AddEntry(newEntry);
            }

            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("What is the filename? ");

                string file = Console.ReadLine();

                journal.LoadFromFile(file);

                Console.WriteLine("Journal loaded successfully.");
            }

            else if (choice == 4)
            {
                Console.Write("What is the filename? ");

                string file = Console.ReadLine();

                journal.SaveToFile(file);

                Console.WriteLine("Journal saved successfully.");
            }

            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}