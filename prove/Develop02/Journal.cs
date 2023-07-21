using System;
using System.Collections.Generic;

class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date.ToString("yyyy-mm-dd")}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response:{entry.Response}\n");
        }
    }

    public void SaveJournal(string filename)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                file.WriteLine(entry.Date.ToString("yyyy-mm-dd"));
                file.WriteLine(entry.Prompt);
                file.WriteLine(entry.Response);
                file.WriteLine();
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }
    
    public void LoadJournal (string filename)
    {
        entries.Clear();
        try
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            // check if the number of lines is a multiple of 4
            if (lines.Length % 4!= 0)
            {
                Console.WriteLine("Invalid journal file format. Unable to load the journal.");
                return;
            }

            for (int i = 0; i < lines.Length; i += 4)
            {
                DateTime date = DateTime.ParseExact(lines[i], "yyyy-mm-dd", System.Globalization.CultureInfo.InvariantCulture);
                string prompt = lines[i + 1];
                string response = lines[i + 2];
                Entry entry = new Entry(prompt, response);
                entries.Add(entry);
            }
            Console.WriteLine("Journal loaded successfully.");

        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("Journal file not found.");
        }
    }

}

class Program
{
    static void Main()
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
