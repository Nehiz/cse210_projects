using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // declear an empty list to store the integer number entered by the user.
        List<int> numbers = new List<int>();
        int number;

        // a do-while loop to repeatedly prompt the user for a number and add it to the list.
        // the loop continues until the user enters 0.
        do
        {
            //Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            Console.Write("Enter number: "); // to read the line of text input from the user.
            number = int.Parse(Console.ReadLine()); // to convert the text input from the user into an integer. alternative 
            //alternative way to converted the input string will be to use the code "string input = Console.readLine();" and then int num = int.parse(input);


            // to add the number to the list if the user input is not 0 and exit if the input is 0.
            if (number != 0)
            {
                numbers.Add(number);
            }
        }while (number != 0);

        Console.WriteLine("The numbers you entered are:");
        // print the content of the list to the console.
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        int total = numbers.Sum(); // to get the sum of the numbers entered by the user.
        Console.WriteLine("The sum of the numbers in your list is: " + total);

        double average = numbers.Average(); // to get the average of the numbers in the list.
        Console.WriteLine($" The Average of the numbers is {average}");

        int maxNumber = numbers.Max();
        Console.WriteLine(" The maximun number in the list is: " + maxNumber);    }    
}
