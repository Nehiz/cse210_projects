using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the scriture reference (e.g, John 3:16):");
        string refrence = Console.ReadLine();

        Console.WriteLine("Enter the scripture text:");
        string text = Console.ReadLine();

        Scripture scripture = new Scripture(refrence, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.FullReference);
            scripture.HideRandomWord();
            Console.WriteLine("Press Enter to continue or type 'quit' to end.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
        }
    }
}