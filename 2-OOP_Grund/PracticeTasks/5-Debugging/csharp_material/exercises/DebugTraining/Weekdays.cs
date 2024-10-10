namespace DebugExample
{
    public class Weekdays
    {
        // During a certain day this code will crash.
        // 1) How are you to find out what day?
        // Answer:  Today is Friday, so let's pretend Friday is the last day of the week by removing Saturday and Sunday from the weekdays-array
        //
        // 2) On what line does the problem occur?
        // Answer:  Line 30: Console.WriteLine("Tomorrow will be: " + weekdays[tomorrowIndex]);
        //
        // 3) What is the problem? Read the error message and check with the debugger.
        // Answer:  The problem is that the tomorrowIndex gets a value that is outside of the index range of the weekdays-array
        //
        // 4) How will you fix it? Note: the soloution might be found on another line than the one causing the crasch
        // Answer:  Since the array's index is 0-based, I subtract 1 before sending the value to todayIndex.
        //          Then I check if today is the last day of the week, and uses an if else-statement to set tomorrowIndex correctly
        //
        public static void TodayAndTomorrow()
        {
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            // We use DateTime to get the day of the week index (0 based).
            int todayIndex = (int)DateTime.Now.DayOfWeek - 1;
            System.Console.WriteLine("Today's index: " + todayIndex);
            int tomorrowIndex;

            // If todayIndex is last day of the week (last index of the array)
            if (todayIndex == weekdays.Length - 1)
            {
                // Set tomorrowIndex to first index of array
                tomorrowIndex = todayIndex - weekdays.Length + 1;
            }
            else
            {
                tomorrowIndex = todayIndex + 1;
            }

            Console.WriteLine("Today is: " + weekdays[todayIndex]);
            Console.WriteLine("Tomorrow will be: " + weekdays[tomorrowIndex]);
            Program.Main();
        }
    }
}