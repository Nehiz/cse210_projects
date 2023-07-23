using System.Collections.Generic;

class Program{
    static void Main()
    {
        Console.WriteLine("Enter the scriture reference (e.g, John 3:16):");
        string reference = Console.ReadLine();

        Console.WriteLine("Enter the scripture text:");
        string text = Console.ReadLine();

        Scripture scripture = new Scripture(reference, text);

        // Display the initial scripture text
        Console.Clear();
        scripture.Display();

        while (!scripture.AllWordsHidden())
        {

            // Hide one random word at a time
            scripture.HideRandomWord();

            // Display the updated scripture text with one word hidden
            Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to end.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
        }
    }
}