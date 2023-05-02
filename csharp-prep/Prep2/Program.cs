using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int percent = int.Parse(userInput);

        string letter = "";
        char sign = '\0';

        if (percent >= 90)
        {
            letter = "A";
        }

        else if (percent >= 80)
        {
            letter = "B";
        }

        else if (percent >= 70)
        {
            letter = "C";
        }

        else if (percent >= 60)
        {
            letter = "D";

        }
        
        else
        {
            letter = "F";
        }

        if (percent % 10 >= 7)
        {
            sign = '+';
        }

        else if (percent % 10 < 3)
        {
            sign = '-';
        }

       //Console.WriteLine($"Your grade is: {letter}");
        if (sign != '\0')
        {
            Console.WriteLine($"{letter}" + sign);
        }

        if (percent >= 70)
        {
            Console.WriteLine("You passed. Congratulations!");
        }
        else
        {
            Console.WriteLine("Try again next term");
        }

    }
}