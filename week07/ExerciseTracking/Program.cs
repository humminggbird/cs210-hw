using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2026, 6, 16), 40, 4.5),
            new Cycling(new DateTime(2026, 6, 15), 60, 18.0),
            new Swimming(new DateTime(2026, 6, 14), 35, 30)
            };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
