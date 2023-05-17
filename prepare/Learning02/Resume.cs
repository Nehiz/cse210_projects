using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>(); // this initializes the list to a new list before it came be used.

    public void Display()
    {
        Console.WriteLine($"Full Name: {_name}");
        Console.WriteLine($"Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display(); // this will will call the Display method on each job
        }

    }

}
