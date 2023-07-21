using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();

        while (true)
        {
            Console.WriteLine("Journaling Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    Entry entry = new Entry(prompt, response);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added successfully.\n");
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    string filenameToSave = Console.ReadLine();
                    journal.SaveJournal(filenameToSave);
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal: ");
                    string filenameToLoad  = Console.ReadLine();
                    journal.SaveJournal(filenameToLoad);
                    break;
                case "5":
                    Console.Write("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;

            }

        }
    }
}