using System;

class MyNumber
{
    static void Main(string[] args)
    {
        //for when user provides the magic number
        //Console.Write("What is your magic number? ");  // ask the user for the magic number
        //int magicNumber = int.Parse(Console.ReadLine()); // store it in a variable called magicNumber
        
        // code to have the computer generates random number for the guess game.
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = 0; // initializes the variable guess to the value of 0 which is not a valid guess before we start the while loop. This prevent the computer from returning error.
        while (guess != magicNumber) // a while loop to prompt the user for guesses and update the value of the guess with the user input
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher ");
            }

            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("You guessed right");
            }
        }
        
    }
}