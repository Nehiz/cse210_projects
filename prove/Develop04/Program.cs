using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Mindfulness App!");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

            if (choice == 4)
            {
                break;
            }

            Console.WriteLine("Enter the duration for the activity (in seconds):");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }

            BaseActivity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity(duration);
                    break;
                case 2:
                    activity = new ReflectionActivity(duration);
                    break;
                case 3:
                    activity = new ListingActivity(duration);
                    break;
                default:
                    activity = null;
                    break;
            }

            if (activity != null)
            {
                activity.RunActivity();
            }
        }
    }
}
