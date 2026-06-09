using System;

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to the Mindfulness Program\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start a breathing activity");
            Console.WriteLine("  2. Start a reflection activity");
            Console.WriteLine("  3. Start a listing activity");
            Console.WriteLine("  4. Start a gratitude activity");
            Console.WriteLine("  5. View activity log");
            Console.WriteLine("  6. Quit");
            Console.WriteLine("\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    log.DisplayLog();
                    continue;
                case "6":
                    Console.WriteLine("\nGoodbye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    continue;
            }

            activity.Run();
            log.RecordActivity(activity.GetName());
        }
    }

    // How I exceed the requirements: I added a Gratitude Activity to the menu as a fourth
    // mindfulness option beyond the required three. I also added an Activity Log that keeps
    // track of how many times each activity has been completed during the session.
    // The user can view the Activity Log directly from the main menu at any time.
}