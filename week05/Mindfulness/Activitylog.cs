using System;
using System.Collections.Generic;

public class ActivityLog
{
    private Dictionary<string, int> _log = new Dictionary<string, int>();

    public void RecordActivity(string activityName)
    {
        if (_log.ContainsKey(activityName))
        {
            _log[activityName]++;
        }
        else
        {
            _log[activityName] = 1;
        }
    }

    public void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("\n--- Activity Log ---\n");

        if (_log.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            foreach (KeyValuePair<string, int> entry in _log)
            {
                Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
            }
        }

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}