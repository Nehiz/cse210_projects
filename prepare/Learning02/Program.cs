using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Lab assistant";
        job1._company = "Nehis Biochemicals";
        job1._startYear = 2017;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Facilitator";
        job2._company = "ChemCrystals";
        job2._startYear = 2022;
        job2._endYear = 2023;
        
        Resume myResume = new Resume();
        myResume._name = "Nehikhare Efehi";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}