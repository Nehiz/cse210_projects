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
