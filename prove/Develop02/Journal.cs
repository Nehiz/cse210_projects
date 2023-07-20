using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry // create a class to represent a journal entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach ( var entry in entries)
        {
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine();
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach(var entry in entries)
            {
                writer.WriteLine($"{entry.Prompt},{entry.Response},{entry.Date}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    JournalEntry entry = new JournalEntry
                    {
                        Prompt = parts[0],
                        Response = parts[1],
                        Date = parts[2]
                    };

                    entries.Add(entry);
                }
            }
        }
    }
    
}

class Program // program class to handle the user interaction and menu option
{
    private Journal journal;

    public Program()
    {
        journal = new Journal();
    }

    public void Run()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Journal Program Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the Journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid. Enter a correct choice.");
                    break;

            }

            Console.WriteLine();
        }
    }

    private void WriteNewEntry()
    {
        Console.WriteLine("Enter your response to the prompt below:");

        string[] prompts = {
            "Who was the most insteresting person i interacted with today? ",
            "What was the best part of my day" ,
            "How did i see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "Iff I had one thing i could do over today, What would it be?"
        
        };

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.WriteLine("Enter your response:");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        JournalEntry entry = new JournalEntry
        {
            Prompt = randomPrompt,
            Response = response,
            Date = date
        };

        Journal.AddEntry(entry);

        Console.WriteLine("Your Entry was added successfully");
        Console.WriteLine();

    }

    private void DisplayJournal()
    {
        journal.DisplayJournal();
    }

    private void SaveJournal()
    {
        Console.WriteLine("Enter the filename: ");
        string filename = Console.ReadLine();
        journal.SaveJournal(filename);
        Console.WriteLine("Saved successfully");
        Console.WriteLine();
    }

    private void LoadJournal()
    {
        Console.WriteLine("Enter the filename:");
        journal.LoadJournal(filename);
        Console.WriteLine("Journal successfully loaded.");
        Console.WriteLine();
    }
        
}

