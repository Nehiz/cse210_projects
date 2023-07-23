using System;
using System.Threading;

abstract class BaseActivity
{
    protected int durationInSeconds;

    public BaseActivity(int duration)
    {
        durationInSeconds = duration;
    }

    public abstract void RunActivity();
}

class BreathingActivity : BaseActivity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void RunActivity()
    {
        Console.WriteLine("Starting Breathing Activity...");
        // Implement breathing activity prompt here.
        Thread.Sleep(durationInSeconds * 1000); // Pausing for the specified duration
        Console.WriteLine("Breathing Activity Completed. Good job!");
        Thread.Sleep(2000); // Pause after completion
    }
}

class ReflectionActivity : BaseActivity
{
    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void RunActivity()
    {
        Console.WriteLine("Starting Reflection Activity...");
        // Implement reflection activity prompt here.
        Thread.Sleep(durationInSeconds * 1000); // Pausing for the specified duration
        Console.WriteLine("Reflection Activity Completed. Good job!");
        Thread.Sleep(2000); // Pause after completion
    }
}

class ListingActivity : BaseActivity
{
    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void RunActivity()
    {
        Console.WriteLine("Starting Listing Activity...");
        // Implement listing activity prompt here.
        Thread.Sleep(durationInSeconds * 1000); // Pausing for the specified duration
        Console.WriteLine("Listing Activity Completed. Good job!");
        Thread.Sleep(2000); // Pause after completion
    }
}
